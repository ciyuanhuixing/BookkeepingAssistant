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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string dir = ConfigHelper.GetValue("GitRepositoryDir");
            if (string.IsNullOrWhiteSpace(dir))
            {
                dir = Path.Combine(Directory.GetCurrentDirectory(), "记账");
            }
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (!Repository.IsValid(dir))
            {
                Repository.Init(dir);
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
    }
}
