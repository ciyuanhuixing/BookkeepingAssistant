using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookkeepingAssistant
{
    public class DAL
    {
        private const string _gitName = "ciyuanhuixing";
        private const string _gitEmail = "ciyuanhuixing@qq.com";

        private string _repositoryDir;
        private string _assetsDataFile;
        private string _transactionTypeDataFile;
        private string _transactionRecordDataFile;
        private Repository _repo;

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
            _repositoryDir = ConfigHelper.GetValue("GitRepositoryDir");
            if (string.IsNullOrWhiteSpace(_repositoryDir))
            {
                _repositoryDir = Path.Combine(Directory.GetCurrentDirectory(), "记账");
            }
            if (!Directory.Exists(_repositoryDir))
            {
                Directory.CreateDirectory(_repositoryDir);
            }
            if (!Repository.IsValid(_repositoryDir))
            {
                Repository.Init(_repositoryDir);
            }
            _repo = new Repository(_repositoryDir);

            _assetsDataFile = Path.Combine(_repositoryDir, "资产.txt");
            _transactionTypeDataFile = Path.Combine(_repositoryDir, "交易类型.txt");
            _transactionRecordDataFile = Path.Combine(_repositoryDir, "交易记录.txt");

            CheckoutLastPushFile();
            ReadData();
        }

        private void CheckoutLastPushFile()
        {
            List<string> paths = new List<string>() {
                GetGitRelativePath(_assetsDataFile),
                GetGitRelativePath(_transactionTypeDataFile),
                GetGitRelativePath(_transactionRecordDataFile)
            };
            CheckoutOptions options = new CheckoutOptions();
            options.CheckoutModifiers = CheckoutModifiers.Force;
            //_repo.Checkout(_repo.Head.TrackedBranch.Tip.Tree, paths, options);
            _repo.CheckoutPaths(_repo.Head.TrackedBranch.Tip.Sha, paths, options);
        }

        private void ReadData()
        {
            if (File.Exists(_assetsDataFile))
            {
                _dicAssets.Clear();
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
                _transactionTypes.Clear();
                string[] lines = File.ReadAllLines(_transactionTypeDataFile);
                foreach (var line in lines)
                {
                    _transactionTypes.Add(line.Trim());
                }
            }

            if (File.Exists(_transactionRecordDataFile))
            {
                _transactionRecords.Clear();
                string[] lines = File.ReadAllLines(_transactionRecordDataFile);
                foreach (var line in lines)
                {
                    string[] arr = line.Trim().Split('|');
                    if (arr.Length != 6)
                    {
                        continue;
                    }

                    TransactionRecordModel record = new TransactionRecordModel();
                    DateTime time;
                    if (!DateTime.TryParse(arr[0].Trim(), out time))
                    {
                        continue;
                    }
                    record.Time = time;

                    if (arr[1].Trim() != "收" && arr[1] != "支")
                    {
                        continue;
                    }
                    record.isIncome = arr[1].Trim() == "收" ? true : false;

                    decimal amount;
                    if (!decimal.TryParse(arr[2], out amount))
                    {
                        continue;
                    }
                    record.Amount = amount;

                    record.AssetName = arr[3].Trim();
                    if (string.IsNullOrEmpty(record.AssetName))
                    {
                        continue;
                    }

                    decimal assetValue;
                    if (!decimal.TryParse(arr[4], out assetValue))
                    {
                        continue;
                    }
                    record.AssetValue = assetValue;

                    record.TransactionType = arr[5].Trim();
                    if (string.IsNullOrEmpty(record.TransactionType))
                    {
                        continue;
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
                CheckoutLastPushFile();
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
                CheckoutLastPushFile();
                ReadData();
                throw;
            }
        }

        public void AddAsset(string assetName, decimal assetValue)
        {
            _dicAssets.Add(assetName, assetValue);
            PossibleRollback(SaveAssets);
        }

        public void RemoveAsset(string assetName)
        {
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
            _transactionTypes.Add(name);
            PossibleRollback(SaveTransactionTypes);
        }

        public void RemoveTransactionType(string name)
        {
            _transactionTypes.Remove(name);
            PossibleRollback(SaveTransactionTypes);
        }

        public void AppendTransactionRecord(TransactionRecordModel tr)
        {
            decimal assetValue = _dicAssets[tr.AssetName];
            if (tr.isIncome)
            {
                assetValue += tr.Amount;
            }
            else
            {
                assetValue -= tr.Amount;
            }
            _dicAssets[tr.AssetName] = assetValue;
            tr.AssetValue = assetValue;
            _transactionRecords.Add(tr);

            PossibleRollback(SaveTransactionRecord, tr);
        }

        private void SaveTransactionRecord(TransactionRecordModel tr)
        {
            WriteAssetsDataFile();
            File.AppendAllLines(_transactionRecordDataFile,
                new List<string>() { string.Join('|', tr.Time, tr.isIncome ? "收" : "支", tr.Amount, tr.AssetName, tr.AssetValue, tr.TransactionType) });

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
            return Path.GetRelativePath(_repositoryDir, filePath);
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

            Signature signature = new Signature(_gitName, _gitEmail, DateTimeOffset.Now);
            _repo.Commit(commitMsg, signature, signature);
            _repo.Network.Push(_repo.Head);
        }
    }
}
