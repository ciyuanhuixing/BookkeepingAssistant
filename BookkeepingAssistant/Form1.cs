using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LibGit2Sharp;

namespace BookkeepingAssistant
{
    public partial class Form1 : Form
    {
        private string _repositoryDir;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

            string assetType = ConfigHelper.GetValue("AssetType").Trim();
            string[] arrAssetType=null;
            if (!string.IsNullOrEmpty(assetType))
            {
                arrAssetType = assetType.Split('|');
                comboBoxAssetType.DataSource = arrAssetType;
            }

            string transactionType = ConfigHelper.GetValue("TransactionType").Trim();
            string[] arrTransactionType;
            if (!string.IsNullOrEmpty(transactionType))
            {
                arrTransactionType = transactionType.Split('|');
                comboBoxTransactionType.DataSource = arrTransactionType;
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelModifyAssets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModifyAssets modifyAssets = new ModifyAssets(Path.Combine(_repositoryDir,"资产.txt"));
            modifyAssets.ShowDialog();
        }
    }
}
