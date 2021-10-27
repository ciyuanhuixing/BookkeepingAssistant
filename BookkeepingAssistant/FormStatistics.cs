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
            dtMonth.Columns.Add("月度总收入");
            dtMonth.Columns.Add("月度总支出");

            var monthsData = _models.GroupBy(o => o.Time.ToString("yyyy-MM")).OrderByDescending(o => o).ToList();
            foreach (var month in monthsData)
            {
                var monthIn = month.Where(o => o.isIncome).ToList();
                var monthOut = month.Where(o => !o.isIncome).ToList();
                var monthRefundAmount = monthIn.Where(o => !string.IsNullOrWhiteSpace(o.RefundLinkId)).Sum(o => o.Amount);

                var monthInTypes = monthIn.GroupBy(o => o.TransactionType).ToList();
                var monthOutTypes = monthOut.GroupBy(o => o.TransactionType).ToList();
                Dictionary<string, decimal> monthInTypesAmount = new Dictionary<string, decimal>();
                Dictionary<string, decimal> monthOutTypesAmount = new Dictionary<string, decimal>();

                Dictionary<string, decimal> monthTypesRefundAmount = new Dictionary<string, decimal>();
                foreach (var inType in monthInTypes)
                {
                    var inTypeAmount = inType.Sum(o => o.Amount);
                    var typeRefundAmount = inType.Where(o => !string.IsNullOrWhiteSpace(o.RefundLinkId)).Sum(o => o.Amount);
                    if (typeRefundAmount > 0)
                    {
                        monthTypesRefundAmount.Add(inType.Key, typeRefundAmount);
                        inTypeAmount -= typeRefundAmount;
                    }
                    if (inTypeAmount != 0)
                    {
                        monthInTypesAmount.Add(inType.Key, inTypeAmount);
                    }
                }
                foreach (var outType in monthOutTypes)
                {
                    var outTypeAmount = outType.Sum(o => o.Amount);
                    if (monthTypesRefundAmount.ContainsKey(outType.Key))
                    {
                        outTypeAmount += monthTypesRefundAmount[outType.Key];
                    }
                    if (outTypeAmount != 0)
                    {
                        monthOutTypesAmount.Add(outType.Key, outTypeAmount);

                        string columnName = $"[{outType.Key}]支出";
                        if (!dtMonth.Columns.Contains(columnName))
                        {
                            dtMonth.Columns.Add(columnName);
                        }
                        rowItems.Add(columnName, outTypeAmount);
                    }
                }

                foreach (var typeAndAmount in monthInTypesAmount)
                {
                    string columnName = $"[{typeAndAmount.Key}]收入";
                    if (!dtMonth.Columns.Contains(columnName))
                    {
                        dtMonth.Columns.Add(columnName);
                    }
                    row[columnName] = typeAndAmount.Value;
                }

                var row = dtMonth.NewRow();
                dtMonth.Rows.Add(row);
                row["月份"] = month.Key;
                row["月度总收入"] = monthIn.Sum(o => o.Amount) - monthRefundAmount;
                row["月度总支出"] = monthOut.Sum(o => o.Amount) + monthRefundAmount;
            }

            dgvMonth.DataSource = dtMonth;


        }
    }
}
