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

namespace BookkeepingAssistant
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            comboBoxInOut.DataSource = new string[] { "支出", "收入" };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshComboBox();
            RefreshDetailView(Data.SingletonInstance.TransactionRecords);
        }

        private void RefreshDetailView(List<TransactionRecord> records)
        {
            records.Reverse();
            DataTable dt = new DataTable();
            dt.Columns.Add("时间");
            dt.Columns.Add("收支类型");
            dt.Columns.Add("金额");
            dt.Columns.Add("资产名称");
            dt.Columns.Add("交易后该资产余额");
            dt.Columns.Add("交易类型");
            foreach (var item in records)
            {
                DataRow dr = dt.NewRow();
                dr["时间"] = item.Time.ToString("yyyy-MM-dd HH:mm");
                dr["收支类型"] = item.isIncome ? "收入" : "支出";
                dr["金额"] = item.Amount;
                dr["资产名称"] = item.AssetName;
                dr["交易后该资产余额"] = item.AssetValue;
                dr["交易类型"] = item.TransactionType;
                dt.Rows.Add(dr);
            }
            dgvDetail.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TransactionRecord tr = new TransactionRecord();
            tr.Time = DateTime.Now;
            tr.isIncome = (string)comboBoxInOut.SelectedValue == "收入" ? true : false;
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text.Trim(), out amount))
            {
                MessageBox.Show("新增失败：金额不能填入非数字。");
                return;
            }
            tr.Amount = amount;
            tr.AssetName = (string)comboBoxAssets.SelectedValue;
            tr.TransactionType = (string)comboBoxTransactionTypes.SelectedValue;

            Data.SingletonInstance.TransactionRecords.Add(tr);
            Data.SingletonInstance.AppendToTransactionRecordsDataFile(tr);
            RefreshDetailView(Data.SingletonInstance.TransactionRecords);
        }

        private void linkLabelModifyAssets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManageAssets formManageAssets = new FormManageAssets();
            formManageAssets.ShowDialog();
            RefreshComboBox();
        }

        private void linkLabelModifyTransactionType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManageTransactionType formManageTransactionType = new FormManageTransactionType();
            formManageTransactionType.ShowDialog();
            RefreshComboBox();
        }

        private void RefreshComboBox()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = Data.SingletonInstance.DicDisplayAssets;
            comboBoxAssets.DisplayMember = "Value";
            comboBoxAssets.ValueMember = "Key";
            comboBoxAssets.DataSource = bs;

            comboBoxTransactionTypes.DataSource = null;
            comboBoxTransactionTypes.DataSource = Data.SingletonInstance.TransactionTypes;
        }
    }
}
