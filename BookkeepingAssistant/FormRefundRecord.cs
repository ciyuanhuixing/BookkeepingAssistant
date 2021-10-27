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
            dt.Columns.Add("年-月-日  时");
            dt.Columns.Add("收/支");
            dt.Columns.Add("金额");
            dt.Columns.Add("资产");
            dt.Columns.Add("交易后余额");
            dt.Columns.Add("类型");
            dt.Columns.Add("备注");
            foreach (var item in _models)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = item.Id;
                dr["年-月-日  时"] = item.Time.ToString("yyyy-MM-dd  HH");
                dr["收/支"] = item.isIncome ? "收入" : "支出";
                dr["金额"] = item.Amount;
                dr["资产"] = item.AssetName;
                dr["交易后余额"] = item.AssetValue;
                dr["类型"] = item.TransactionType;
                dr["备注"] = item.Remark;
                dt.Rows.Add(dr);
            }
            dgvDetail.DataSource = dt;
            dgvDetail.ClearSelection();
        }
        private void dgvDetail_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvDetail.Rows[e.RowIndex];
            if (row.Cells["收/支"].Value.ToString() == "收入")
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }
    }
}
