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
        private List<TransactionRecordModel> _records;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var config = ConfigHelper.ReadConfig();
            if (!config.IsInit)
            {
                this.Visible = false;
                FormInit formInit = new FormInit();
                formInit.ShowDialog();
                this.Visible = true;
            }

            _records = DAL.Singleton.GetTransactionRecords();
            _records.Reverse();

            comboBoxInOut.DataSource = new string[] { "支出", "收入" };
            if (_records.Any())
            {
                var r = _records.First();
                comboBoxInOut.SelectedItem = r.isIncome ? "收入" : "支出";
            }

            RefreshAssetsControl();
            RefreshTransactionTypesControl();
            RefreshDetailView(_records);
        }

        private void RefreshDetailView(List<TransactionRecordModel> records)
        {
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
            TransactionRecordModel tr = new TransactionRecordModel();
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

            try
            {
                DAL.Singleton.AppendTransactionRecord(tr);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"新增交易记录失败：{ ex.Message}。");
                return;
            }

            _records = DAL.Singleton.GetTransactionRecords();
            _records.Reverse();
            RefreshDetailView(_records);
            RefreshAssetsControl();
            txtAmount.Clear();
        }

        private void linkLabelModifyAssets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManageAssets formManageAssets = new FormManageAssets();
            formManageAssets.ShowDialog();
            RefreshAssetsControl();
        }

        private void linkLabelModifyTransactionType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManageTransactionType formManageTransactionType = new FormManageTransactionType();
            formManageTransactionType.ShowDialog();
            RefreshTransactionTypesControl();
        }

        private void RefreshAssetsControl()
        {
            var assets = DAL.Singleton.GetDisplayAssets();
            if (!assets.Any())
            {
                comboBoxAssets.DataSource = null;
                return;
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = assets;
            comboBoxAssets.DisplayMember = "Value";
            comboBoxAssets.ValueMember = "Key";
            comboBoxAssets.DataSource = bs;
            if (_records.Any())
            {
                var r = _records.First();
                comboBoxAssets.SelectedValue = r.AssetName;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("【所有资产】");
            foreach (var item in assets)
            {
                sb.AppendLine(item.Value);
            }
            txtAssets.Text = sb.ToString();
        }

        private void RefreshTransactionTypesControl()
        {
            var types = DAL.Singleton.GetTransactionTypes();
            if (!types.Any())
            {
                comboBoxTransactionTypes.DataSource = null;
                return;
            }
            comboBoxTransactionTypes.DataSource = types;
            if (_records.Any())
            {
                var r = _records.First();
                comboBoxTransactionTypes.SelectedItem = r.TransactionType;
            }
        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(null, null);
            }
        }
    }
}
