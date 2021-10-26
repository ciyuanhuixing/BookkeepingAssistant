using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace BookkeepingAssistant
{
    public class DAL
    {
        private ConfigModel _config;
        private string _assetsDataFile;
        private string _transactionTypeDataFile;
        private string _transactionRecordDataFile;
        private Repository _repo;
        private bool _haveCommits = false;
        private string _lastCheckoutCommitSha;

        private Dictionary<string, decimal> _dicAssets = new Dictionary<string, decimal>();
        private List<string> _transactionTypes = new List<string>();
        private List<TransactionRecordModel> _transactionRecords = new List<TransactionRecordModel>();

        private static readonly DAL _singletonInstance = new DAL();
        public static DAL Singleton
        {
            get
            {
                return _singletonInstance;
            }
        }

        private DAL()
        {
            _config = ConfigHelper.ReadConfig();
            _repo = new Repository(_config.GitRepoDir);
            if (_repo.Head.TrackedBranch?.Tip != null)
            {
                _haveCommits = true;
            }

            _assetsDataFile = Path.Combine(_config.GitRepoDir, "资产.txt");
            _transactionTypeDataFile = Path.Combine(_config.GitRepoDir, "交易类型.txt");
            _transactionRecordDataFile = Path.Combine(_config.GitRepoDir, "交易记录.txt");

            ReadData();
        }

        public static bool VerifyGitRepo()
        {
            try
            {
                new DAL();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private string CheckoutLastPushFile()
        {
            List<string> paths = new List<string>() {
                _assetsDataFile,
                _transactionTypeDataFile,
                _transactionRecordDataFile
            };
            if (!_haveCommits)
            {
                paths.ForEach(o => File.Delete(o));
                return null;
            }
            CheckoutOptions options = new CheckoutOptions();
            options.CheckoutModifiers = CheckoutModifiers.Force;
            var commit = _repo.Head.TrackedBranch.Tip;
            _repo.Checkout(commit.Tree, paths.Select(o => GetGitRelativePath(o)), options);
            return commit.Sha;
        }

        private void ReadData()
        {
            _lastCheckoutCommitSha = CheckoutLastPushFile();

            _dicAssets.Clear();
            _transactionTypes.Clear();
            _transactionRecords.Clear();

            if (File.Exists(_assetsDataFile))
            {
                string[] assetLines = File.ReadAllLines(_assetsDataFile);
                foreach (var line in assetLines)
                {
                    string[] arr = line.Trim().Split('：', ':');
                    if (arr.Length != 2)
                    {
                        continue;
                    }
                    decimal assetValue;
                    if (!decimal.TryParse(arr[1].Trim(), out assetValue))
                    {
                        continue;
                    }

                    _dicAssets.Add(arr[0].Trim(), assetValue);
                }
            }

            if (File.Exists(_transactionTypeDataFile))
            {
                string[] lines = File.ReadAllLines(_transactionTypeDataFile);
                foreach (var line in lines)
                {
                    _transactionTypes.Add(line.Trim());
                }
            }

            if (File.Exists(_transactionRecordDataFile))
            {
                string[] lines = File.ReadAllLines(_transactionRecordDataFile);
                foreach (var line in lines)
                {
                    string[] arr = line.Split('|');
                    if (arr.Length != 10)
                    {
                        continue;
                    }
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = arr[i].Trim();
                    }

                    TransactionRecordModel record = new TransactionRecordModel();
                    int n = 0;
                    int id;
                    if (!int.TryParse(arr[n++], out id))
                    {
                        continue;
                    }
                    record.Id = id;

                    DateTime time;
                    if (!DateTime.TryParse(arr[n++], out time))
                    {
                        continue;
                    }
                    record.Time = time;

                    string inOut = arr[n++];
                    if (inOut != "收" && inOut != "支")
                    {
                        continue;
                    }
                    record.isIncome = inOut == "收" ? true : false;

                    decimal amount;
                    if (!decimal.TryParse(arr[n++], out amount))
                    {
                        continue;
                    }
                    record.Amount = amount;

                    record.AssetName = arr[n++];
                    if (string.IsNullOrEmpty(record.AssetName))
                    {
                        continue;
                    }

                    decimal assetValue;
                    if (!decimal.TryParse(arr[n++], out assetValue))
                    {
                        continue;
                    }
                    record.AssetValue = assetValue;

                    record.TransactionType = arr[n++];
                    if (string.IsNullOrEmpty(record.TransactionType))
                    {
                        continue;
                    }

                    record.RefundLinkId = arr[n++];
                    record.Remark = arr[n++];

                    int deleteLinkId;
                    if (int.TryParse(arr[n++], out deleteLinkId))
                    {
                        record.DeleteLinkId = deleteLinkId;
                    }
                    else
                    {
                        record.DeleteLinkId = null;
                    }

                    _transactionRecords.Add(record);
                }


            }
        }

        public Dictionary<string, decimal> GetAssets()
        {
            Dictionary<string, decimal> assets = new Dictionary<string, decimal>();
            foreach (var item in _dicAssets)
            {
                assets.Add(item.Key, item.Value);
            }
            return assets;
        }

        public Dictionary<string, string> GetDisplayAssets()
        {
            _dicAssets = _dicAssets.OrderByDescending(o => o.Value).ToDictionary(o => o.Key, o => o.Value);
            Dictionary<string, string> dicDisplayAssets = new Dictionary<string, string>();
            foreach (var kvp in _dicAssets)
            {
                dicDisplayAssets.Add(kvp.Key, string.Join('：', kvp.Key, kvp.Value));
            }
            return dicDisplayAssets;
        }

        public List<string> GetTransactionTypes()
        {
            List<string> types = new List<string>();
            types.AddRange(_transactionTypes);
            return types;
        }

        public List<TransactionRecordModel> GetTransactionRecords()
        {
            List<TransactionRecordModel> records = new List<TransactionRecordModel>();
            records.AddRange(_transactionRecords);

            var deleteLinks = records.Where(o => o.DeleteLinkId.HasValue).ToList();
            var deleteIds = deleteLinks.Select(o => o.DeleteLinkId.Value).ToList();
            deleteIds.AddRange(deleteLinks.Select(o => o.Id));
            records.RemoveAll(o => deleteIds.Contains(o.Id));

            var pays = records.Where(o => !o.isIncome).ToList();
            foreach (var pay in pays)
            {
                var refund = records.Where(o => o.isIncome && o.RefundLinkId.Trim() == pay.Id.ToString()).ToList();
                if (refund.Any())
                {
                    pay.RefundLinkId = string.Join(',', refund.Select(o => o.Id));
                    pay.Remark = refund.Sum(o => o.Amount) + pay.Amount >= 0 ?
                        "[已全额退款]" + pay.Remark : "[已部分退款]" + pay.Remark;
                }
            }

            return records;
        }

        private void WriteAssetsDataFile()
        {
            StringBuilder sbAssets = new StringBuilder();
            foreach (var kvp in _dicAssets)
            {
                sbAssets.AppendLine(string.Join('：', kvp.Key, kvp.Value));
            }
            File.WriteAllText(_assetsDataFile, sbAssets.ToString());
        }

        private void SaveAssets()
        {
            WriteAssetsDataFile();
            StageFile(_assetsDataFile);
            PushGitCommit("新增或删除资产");
        }

        private void PossibleRollback(Action work)
        {
            PossibleRollback<object>(work, null, null);
        }

        private void PossibleRollback<T>(Action<T> work, T obj)
        {
            PossibleRollback(null, work, obj);
        }

        private void PossibleRollback<T>(Action work, Action<T> workWithArg, T obj)
        {
            try
            {
                string sha = CheckoutLastPushFile();
                if (sha != _lastCheckoutCommitSha)
                {
                    throw new Exception("检测到 Git 仓库已被其它程序修改，本程序无法继续运行");
                }
                if (work != null)
                {
                    work();
                }
                else if (workWithArg != null)
                {
                    workWithArg(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ReadData();
            }
        }

        public void AddAsset(string assetName, decimal assetValue)
        {
            if (string.IsNullOrWhiteSpace(assetName))
            {
                throw new Exception("资产名称不能为空");
            }
            _dicAssets.Add(assetName, assetValue);
            PossibleRollback(SaveAssets);
        }

        public void RemoveAsset(string assetName)
        {
            if (string.IsNullOrWhiteSpace(assetName))
            {
                throw new Exception("资产名称不能为空");
            }
            if (_dicAssets[assetName] != 0)
            {
                throw new Exception("该资产余额不为零，不可删除。");
            }
            _dicAssets.Remove(assetName);
            PossibleRollback(SaveAssets);
        }

        private void SaveTransactionTypes()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var asset in _transactionTypes)
            {
                sb.AppendLine(asset);
            }
            File.WriteAllText(_transactionTypeDataFile, sb.ToString());

            StageFile(_transactionTypeDataFile);
            PushGitCommit("新增或删除交易类型");
        }

        public void AddTransactionType(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("交易类型不能为空");
            }
            _transactionTypes.Add(name);
            PossibleRollback(SaveTransactionTypes);
        }

        public void RemoveTransactionType(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("交易类型不能为空");
            }
            _transactionTypes.Remove(name);
            PossibleRollback(SaveTransactionTypes);
        }

        public void AppendTransactionRecord(TransactionRecordModel tr)
        {
            if (string.IsNullOrWhiteSpace(tr.AssetName))
            {
                throw new Exception("资产名称不能为空");
            }
            if (string.IsNullOrWhiteSpace(tr.TransactionType))
            {
                throw new Exception("交易类型不能为空");
            }
            if (tr.Amount == 0)
            {
                throw new Exception("金额不能等于0");
            }

            if (_transactionRecords.Any())
            {
                tr.Id = _transactionRecords.Last().Id + 1;
            }
            tr.Time = DateTime.Now;
            tr.isIncome = tr.Amount > 0 ? true : false;
            _dicAssets[tr.AssetName] += tr.Amount;
            tr.AssetValue = _dicAssets[tr.AssetName];
            _transactionRecords.Add(tr);

            PossibleRollback(SaveTransactionRecord, tr);
        }

        private void SaveTransactionRecord(TransactionRecordModel tr)
        {
            WriteAssetsDataFile();
            File.AppendAllLines(_transactionRecordDataFile,
                new List<string>() {
                    string.Join('|',tr.Id, tr.Time, tr.isIncome ? "收" : "支", tr.Amount, tr.AssetName,
                    tr.AssetValue, tr.TransactionType,tr.RefundLinkId, tr.Remark,tr.DeleteLinkId) });

            StageFile(_transactionRecordDataFile);
            StageFile(_assetsDataFile);
            PushGitCommit("新增收支记录");
        }

        private void StageFile(string filePath)
        {
            Commands.Stage(_repo, GetGitRelativePath(filePath));
        }

        private string GetGitRelativePath(string filePath)
        {
            return Path.GetRelativePath(_config.GitRepoDir, filePath);
        }

        private void PushGitCommit(string commitMsg)
        {
            if (_repo.Head.TrackingDetails.AheadBy > 0)
            {
                commitMsg = "[上次提交未实时推送，所以上次提交无效]" + commitMsg;
                //_repo.Refs.RewriteHistory(new RewriteHistoryOptions()
                //{
                //    CommitHeaderRewriter = c => CommitRewriteInfo.From(c, "[未实时推送，故提交无效]" + c.Message)
                //}, _repo.Head.Tip);
            }

            Signature signature = new Signature(_config.GitUsername, _config.GitEmail, DateTimeOffset.Now);
            _repo.Commit(commitMsg, signature, signature);
            _repo.Network.Push(_repo.Head);
            _haveCommits = true;
        }
    }
}
