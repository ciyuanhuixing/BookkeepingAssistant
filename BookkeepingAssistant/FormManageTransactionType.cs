using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace BookkeepingAssistant
{
    public partial class FormManageTransactionType : Form
    {
        public FormManageTransactionType()
        {
            InitializeComponent();
        }

        private void FormManageTransactionType_Load(object sender, EventArgs e)
        {
            RefreshTransactionTypes();
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            string type = txtType.Text.Trim();
            if (string.IsNullOrEmpty(type))
            {
                FormMessage.Show("新增失败：名称不能为空。");
                return;
            }
            if (DAL.Singleton.GetTransactionTypes().Contains(type))
            {
                FormMessage.Show("新增失败：已存在该名称的交易类型。");
                return;
            }

            DAL.Singleton.AddTransactionType(type);
            RefreshTransactionTypes();
            FormMessage.Show($"已新增「{type}」");
            txtType.Clear();
            txtType.Focus();
        }

        private void RefreshTransactionTypes()
        {
            var types = DAL.Singleton.GetTransactionTypes();
            if (!types.Any())
            {
                btnRemove.Enabled = false;
                comboBoxTypes.DataSource = null;
                return;
            }
            comboBoxTypes.DataSource = types;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string type = (string)comboBoxTypes.SelectedValue;
            if (MessageBox.Show($"确认删除{type}？", "确认删除？", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            DAL.Singleton.RemoveTransactionType(type);
            RefreshTransactionTypes();
        }
    }
}
