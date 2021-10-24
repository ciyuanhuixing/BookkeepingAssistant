using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookkeepingAssistant
{
    public class Data
    {
        private const string _gitName = "ciyuanhuixing";
        private const string _gitEmail = "ciyuanhuixing@qq.com";

        private string _repositoryDir;
        private string _assetsDataFile;
        private string _transactionTypeDataFile;
        private string _transactionRecordDataFile;
        private Repository _repo;

        public Dictionary<string, decimal> DicAssets { get; } = new Dictionary<string, decimal>();
        private Dictionary<string, string> _dicDisplayAssets = new Dictionary<string, string>();
        public Dictionary<string, string> DicDisplayAssets
        {
            get
            {
                _dicDisplayAssets.Clear();
                foreach (var kvp in DicAssets)
                {
                    _dicDisplayAssets.Add(kvp.Key, string.Join('：', kvp.Key, kvp.Value));
                }
                return _dicDisplayAssets;
            }
        }
        public List<string> TransactionTypes { get; } = new List<string>();
        public List<TransactionRecord> TransactionRecords { get; } = new List<TransactionRecord>();

        private static readonly Data _singletonInstance = new Data();
        public static Data SingletonInstance
        {
            get
            {
                return _singletonInstance;
            }
        }

        private Data()
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

            ReadData();
        }

        private void ReadData()
        {
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

                    DicAssets.Add(arr[0].Trim(), assetValue);
                }
            }

            if (File.Exists(_transactionTypeDataFile))
            {
                string[] lines = File.ReadAllLines(_transactionTypeDataFile);
                foreach (var line in lines)
                {
                    TransactionTypes.Add(line.Trim());
                }
            }

            if (File.Exists(_transactionRecordDataFile))
            {
                string[] lines = File.ReadAllLines(_transactionRecordDataFile);
                foreach (var line in lines)
                {
                    string[] arr = line.Trim().Split('|');
                    if (arr.Length != 5)
                    {
                        continue;
                    }

                    TransactionRecord record = new TransactionRecord();
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

                    record.TransactionType = arr[4].Trim();
                    if (string.IsNullOrEmpty(record.TransactionType))
                    {
                        continue;
                    }

                    TransactionRecords.Add(record);
                }
            }
        }

        public void WriteAssetsDataFile()
        {
            StringBuilder sbAssets = new StringBuilder();
            foreach (var kvp in DicAssets)
            {
                sbAssets.AppendLine(string.Join('：', kvp.Key, kvp.Value));
            }
            File.WriteAllText(_assetsDataFile, sbAssets.ToString());

            _repo.Index.Add(Path.GetRelativePath(_repositoryDir, _assetsDataFile));
            Signature signature = new Signature(_gitName, _gitEmail, DateTimeOffset.Now);
            _repo.Commit("新增或删除资产", signature, signature);
            _repo.Network.Push(_repo.Head);
        }

        public void WriteTransactionTypesData()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var asset in TransactionTypes)
            {
                sb.AppendLine(asset);
            }
            File.WriteAllText(_transactionTypeDataFile, sb.ToString());

            _repo.Index.Add(Path.GetRelativePath(_repositoryDir, _transactionTypeDataFile));
            Signature signature = new Signature(_gitName, _gitEmail, DateTimeOffset.Now);
            _repo.Commit("新增或删除交易类型", signature, signature);
            _repo.Network.Push(_repo.Head);
        }

        public void AppendToTransactionRecordsDataFile(TransactionRecord tr)
        {
            List<string> lines = new List<string>();
            lines.Add(string.Join('|', tr.Time, tr.isIncome ? "收" : "支", tr.Amount, tr.AssetName, tr.TransactionType));
            File.AppendAllLines(_transactionRecordDataFile, lines);
            Commands.Stage(_repo, Path.GetRelativePath(_repositoryDir, _transactionRecordDataFile));
            Signature signature = new Signature(_gitName, _gitEmail, DateTimeOffset.Now);
            _repo.Commit("新增收支记录", signature, signature);
            _repo.Network.Push(_repo.Head);
        }
    }
}
