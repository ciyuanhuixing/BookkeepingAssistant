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
            if (!config.IsInit || !DAL.VerifyGitRepo())
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
            dt.Columns.Add("Id");
            dt.Columns.Add("时间");
            dt.Columns.Add("收支类型");
            dt.Columns.Add("金额");
            dt.Columns.Add("资产名称");
            dt.Columns.Add("交易后该资产余额");
            dt.Columns.Add("交易类型");
            dt.Columns.Add("退款关联Id");
            dt.Columns.Add("备注");
            foreach (var item in records)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = item.Id;
                dr["时间"] = item.Time.ToString("yyyy-MM-dd HH:mm");
                dr["收支类型"] = item.isIncome ? "收入" : "支出";
                dr["金额"] = item.Amount;
                dr["资产名称"] = item.AssetName;
                dr["交易后该资产余额"] = item.AssetValue;
                dr["交易类型"] = item.TransactionType;
                dr["退款关联Id"] = item.RefundLinkId;
                dr["备注"] = item.Remark;
                dt.Rows.Add(dr);
            }
            dgvDetail.DataSource = dt;
            dgvDetail.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TransactionRecordModel tr = new TransactionRecordModel();
            tr.Time = DateTime.Now;
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text.Trim(), out amount))
            {
                MessageBox.Show("新增失败：金额不能填入非数字。");
                return;
            }
            tr.Amount = amount;
            tr.AssetName = (string)comboBoxAssets.SelectedValue;
            tr.TransactionType = (string)comboBoxTransactionTypes.SelectedValue;
            tr.Remark = txtRemake.Text.Trim();
            AddTransactionRecord(tr);

            if (txtAmount.Text.Trim().StartsWith('-'))
            {
                txtAmount.Text = "-";
                txtAmount.Select(txtAmount.Text.Length, 0);
            }
            else
            {
                txtAmount.Clear();
            }
            txtRemake.Clear();
        }

        private void AddTransactionRecord(TransactionRecordModel tr)
        {
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

        private void dgvDetail_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvDetail.Rows[e.RowIndex];
            if (row.Cells["收支类型"].Value.ToString() == "收入")
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选中一行记录。");
                return;
            }
            int id = int.Parse(dgvDetail.SelectedRows[0].Cells["Id"].Value.ToString());
            var record = _records.Single(o => o.Id == id);
            if (record.isIncome)
            {
                MessageBox.Show("收入不可退款。");
                return;
            }
            var linkIds = record.RefundLinkId.Split(',').Where(o => !string.IsNullOrWhiteSpace(o)).ToList();
            var totalRefundAmount = _records.Where(o => linkIds.Contains(o.Id.ToString())).Sum(o => o.Amount);
            if (totalRefundAmount + record.Amount >= 0)
            {
                MessageBox.Show("此支出已全额退款，不可再次退款。");
                return;
            }

            FormRefund formRefund = new FormRefund(Math.Abs(record.Amount) - totalRefundAmount);
            if (formRefund.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            TransactionRecordModel model = new TransactionRecordModel();
            model.Time = DateTime.Now;
            model.AssetName = record.AssetName;
            model.TransactionType = record.TransactionType;
            model.Amount = formRefund.RefundAmount;
            model.RefundLinkId = record.Id.ToString();
            model.Remark = formRefund.RefundAmount >= Math.Abs(record.Amount) ? "[全额退款]" : "[部分退款]";
            AddTransactionRecord(model);
        }

        private void dgvDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedRows.Count == 0)
            {
                return;
            }
            int id = int.Parse(dgvDetail.SelectedRows[0].Cells["Id"].Value.ToString());
            var record = _records.Single(o => o.Id == id);
            if (record.isIncome)
            {
                btnRefund.Enabled = false;
                return;
            }
            var linkIds = record.RefundLinkId.Split(',').Where(o => !string.IsNullOrWhiteSpace(o)).ToList();
            var totalRefundAmount = _records.Where(o => linkIds.Contains(o.Id.ToString())).Sum(o => o.Amount);
            if (totalRefundAmount + record.Amount >= 0)
            {
                btnRefund.Enabled = false;
                return;
            }

            btnRefund.Enabled = true;
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text.TrimStart().StartsWith('-'))
            {
                comboBoxInOut.SelectedItem = "支出";
            }
            else
            {
                comboBoxInOut.SelectedItem = "收入";
            }
        }

        private void comboBoxInOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxInOut.SelectedItem.ToString() == "收入")
            {
                txtAmount.BackColor = Color.LightGreen;
                txtAmount.Text = txtAmount.Text.Trim().TrimStart('-');
            }
            else
            {
                txtAmount.BackColor = Color.White;
                if (!txtAmount.Text.Trim().StartsWith('-'))
                {
                    txtAmount.Text = '-' + txtAmount.Text.Trim();
                    txtAmount.Select(txtAmount.Text.Length, 0);
                }
            }
        }

        private void txtAmount_Enter(object sender, EventArgs e)
        {
            txtAmount.Select(txtAmount.Text.Length, 0);
        }
    }
}
