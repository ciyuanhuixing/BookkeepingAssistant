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
        public List<string> _transactionTypes = Data.SingletonInstance.TransactionTypes;

        public FormManageTransactionType()
        {
            InitializeComponent();
        }

        private void FormManageTransactionType_Load(object sender, EventArgs e)
        {
            DisplayTransactionTypes();
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            string type = txtType.Text.Trim();
            if (string.IsNullOrEmpty(type))
            {
                MessageBox.Show("新增失败：名称不能为空。");
                return;
            }
            if (_transactionTypes.Contains(type))
            {
                MessageBox.Show("新增失败：已存在该名称的交易类型。");
                return;
            }

            _transactionTypes.Add(type);
            Data.SingletonInstance.WriteTransactionTypesData();
            DisplayTransactionTypes();
            MessageBox.Show($"已新增「{type}」");
        }

        private void DisplayTransactionTypes()
        {
            comboBoxTypes.DataSource = null;
            comboBoxTypes.DataSource = _transactionTypes;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string type = (string)comboBoxTypes.SelectedValue;
            if (MessageBox.Show($"确认删除{type}？", "确认删除？", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            _transactionTypes.Remove(type);
            Data.SingletonInstance.WriteTransactionTypesData();
            DisplayTransactionTypes();
        }
    }
}
