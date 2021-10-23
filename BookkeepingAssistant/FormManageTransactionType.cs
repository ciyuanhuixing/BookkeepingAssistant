using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BookkeepingAssistant
{
    public partial class FormManageTransactionType : Form
    {
        private string _dataFile;
        private List<string> _transactionTypes = new List<string>();

        public FormManageTransactionType(string dataFile)
        {
            if (string.IsNullOrWhiteSpace(dataFile))
            {
                throw new Exception("交易类型数据文件路径不能为空。");
            }
            _dataFile = dataFile;
            InitializeComponent();
        }

        private void FormManageTransactionType_Load(object sender, EventArgs e)
        {
            if (!File.Exists(_dataFile))
            {
                return;
            }

            string[] lines = File.ReadAllLines(_dataFile);
            foreach (var line in lines)
            {
                _transactionTypes.Add(line.Trim());
            }

            DisplayTransactionTypes();
        }

        private void addType_Click(object sender, EventArgs e)
        {
            string type = txtType.Text.Trim();
            if (_transactionTypes.Contains(type))
            {
                MessageBox.Show("新增失败：已存在该名称的交易类型。");
                return;
            }

            _transactionTypes.Add(type);
            WriteAssetsDataFile();
            MessageBox.Show($"已新增「{type}」");
        }

        private void DisplayTransactionTypes()
        {
            comboBoxTypes.DataSource = null;
            comboBoxTypes.DataSource = _transactionTypes;
        }

        private void WriteAssetsDataFile()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var asset in _transactionTypes)
            {
                sb.AppendLine(asset);
            }
            File.WriteAllText(_dataFile, sb.ToString());
            DisplayTransactionTypes();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string type = (string)comboBoxTypes.SelectedValue;
            if (MessageBox.Show($"确认删除{type}？", "确认删除？", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            _transactionTypes.Remove(type);
            WriteAssetsDataFile();
        }
    }
}
