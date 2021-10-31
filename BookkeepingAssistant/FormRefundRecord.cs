using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookkeepingAssistant
{
    public partial class FormRefundRecord : Form
    {
        private List<TransactionRecordModel> _models;
        public FormRefundRecord(List<TransactionRecordModel> models)
        {
            InitializeComponent();
            _models = models;
        }

        private void FormRefundRecord_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("年-月-日");
            dt.Columns.Add("金额", typeof(int));
            dt.Columns.Add("交易类型");
            dt.Columns.Add("资产");
            dt.Columns.Add("交易后该资产余额");
            dt.Columns.Add("交易后所有资产总余额");
            dt.Columns.Add("备注");
            foreach (var item in _models)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = item.Id;
                dr["年-月-日"] = item.Time.ToString(DAL.TimeFormat);
                dr["金额"] = item.Amount;
                dr["交易类型"] = item.TransactionType;
                dr["资产"] = item.AssetName;
                dr["交易后该资产余额"] = item.AssetValue;
                dr["交易后所有资产总余额"] = item.AssetsTotalValue;
                dr["备注"] = item.Remark;
                dt.Rows.Add(dr);
            }
            dgvDetail.DataSource = dt;
            dgvDetail.ClearSelection();
        }
        private void dgvDetail_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvDetail.Rows[e.RowIndex];
            if ((int)row.Cells["金额"].Value > 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void FormRefundRecord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
        }
    }
}
