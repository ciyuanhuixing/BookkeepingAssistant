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
            dgvMonth.DataSource = GetStatisticsTable(true);
            dgvYear.DataSource = GetStatisticsTable(false);
        }

        private DataTable GetStatisticsTable(bool isMonth)
        {
            string timeUnit = isMonth ? "月" : "年";

            DataTable dtMonth = new DataTable();
            dtMonth.Columns.Add($"{timeUnit}份");
            dtMonth.Columns.Add($"{timeUnit}度总收入");
            dtMonth.Columns.Add($"{timeUnit}度总支出");
            dtMonth.Columns.Add($"{timeUnit}度盈余");

            var monthsData = _models.GroupBy(o => o.Time.ToString(isMonth ? "yyyy-MM" : "yyyy")).OrderByDescending(o => o).ToList();
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
                        string columnName = $"【{inType.Key}】收入";
                        monthInTypesAmount.Add(columnName, inTypeAmount);
                        if (!dtMonth.Columns.Contains(columnName))
                        {
                            dtMonth.Columns.Add(columnName);
                        }
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
                        string columnName = $"【{outType.Key}】支出";
                        monthOutTypesAmount.Add(columnName, outTypeAmount);
                        if (!dtMonth.Columns.Contains(columnName))
                        {
                            dtMonth.Columns.Add(columnName);
                        }
                    }
                }

                var row = dtMonth.NewRow();
                dtMonth.Rows.Add(row);
                row[$"{timeUnit}份"] = month.Key;
                var inAmount = monthIn.Sum(o => o.Amount) - monthRefundAmount;
                var outAmount = monthOut.Sum(o => o.Amount) + monthRefundAmount;
                row[$"{timeUnit}度总收入"] = inAmount;
                row[$"{timeUnit}度总支出"] = outAmount;
                row[$"{timeUnit}度盈余"] = inAmount + outAmount;
                foreach (var typeAndAmount in monthInTypesAmount)
                {
                    row[typeAndAmount.Key] = typeAndAmount.Value;
                }
                foreach (var typeAndAmount in monthOutTypesAmount)
                {
                    row[typeAndAmount.Key] = typeAndAmount.Value;
                }
            }
            return dtMonth;
        }
    }
}
