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
    public partial class FormMain : Form
    {
        private string _repositoryDir;
        public FormMain()
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

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelModifyAssets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManageAssets formManageAssets = new FormManageAssets(Path.Combine(_repositoryDir,"资产.txt"));
            formManageAssets.ShowDialog();
        }

        private void linkLabelModifyTransactionType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManageTransactionType formManageTransactionType =new FormManageTransactionType(Path.Combine(_repositoryDir, "交易类型.txt"));
            formManageTransactionType.ShowDialog();
        }
    }
}
