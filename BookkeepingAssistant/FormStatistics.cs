using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace BookkeepingAssistant
{
    public partial class FormStatistics : Form
    {
        private List<TransactionRecordModel> _models = new List<TransactionRecordModel>();

        public FormStatistics(List<TransactionRecordModel> models)
        {
            InitializeComponent();
            _models.AddRange(models);
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            DataTable dtMonth = new DataTable();
            dtMonth.Columns.Add("月份");

            //Dictionary<string, List<decimal>> dicRowData = new Dictionary<string, List<decimal>>();
            //dicRowData.Add("月度总收入", new List<decimal>());
            //dicRowData.Add("月度总支出", new List<decimal>());

            dtMonth.Columns.Add("月度总收入");
            dtMonth.Columns.Add("月度总支出");

            var monthsData = _models.GroupBy(o => o.Time.ToString("yyyy-MM")).OrderByDescending(o => o).ToList();
            foreach (var month in monthsData)
            {
                Dictionary<string, object> rowItems = new Dictionary<string, object>();
                rowItems.Add("月份", month.Key);

                var monthIn = month.Where(o => o.isIncome).ToList();
                var monthOut = month.Where(o => !o.isIncome).ToList();
                var monthRefundAmount = monthIn.Where(o => !string.IsNullOrWhiteSpace(o.RefundLinkId)).Sum(o => o.Amount);

                rowItems.Add("月度总收入", monthIn.Sum(o => o.Amount) - monthRefundAmount);
                rowItems.Add("月度总支出", monthOut.Sum(o => o.Amount) + monthRefundAmount);

                var monthInTypes = monthIn.GroupBy(o => o.TransactionType).ToList();
                var monthOutTypes = monthOut.GroupBy(o => o.TransactionType).ToList();

                Dictionary<string, decimal> dicTypeRefundAmount = new Dictionary<string, decimal>();
                foreach (var inType in monthInTypes)
                {
                    var inTypeAmount = inType.Sum(o => o.Amount);
                    var typeRefundAmount = inType.Where(o => !string.IsNullOrWhiteSpace(o.RefundLinkId)).Sum(o => o.Amount);
                    if (typeRefundAmount > 0)
                    {
                        dicTypeRefundAmount.Add(inType.Key, typeRefundAmount);
                        inTypeAmount -= typeRefundAmount;
                    }
                    string columnName = $"[{inType.Key}]收入";
                    if (inTypeAmount != 0)
                    {
                        if (!dtMonth.Columns.Contains(columnName))
                        {
                            dtMonth.Columns.Add(columnName);
                        }
                        rowItems.Add(columnName, inTypeAmount);
                    }
                }
                foreach (var outType in monthOutTypes)
                {
                    var outTypeAmount = outType.Sum(o => o.Amount);
                    if (dicTypeRefundAmount.ContainsKey(outType.Key))
                    {
                        outTypeAmount += dicTypeRefundAmount[outType.Key];
                    }
                    if (outTypeAmount != 0)
                    {
                        string columnName = $"[{outType.Key}]支出";
                        if (!dtMonth.Columns.Contains(columnName))
                        {
                            dtMonth.Columns.Add(columnName);
                        }
                        rowItems.Add(columnName, outTypeAmount);
                    }
                }
                dtMonth.Rows.Add(rowItems.Values.ToArray());
            }

            dgvMonth.DataSource = dtMonth;


        }
    }
}
