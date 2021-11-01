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
        private List<TransactionRecordModel> _models;

        public FormStatistics(List<TransactionRecordModel> models)
        {
            InitializeComponent();
            List<string> excludeTypes = new TransferType[] { TransferType.借款, TransferType.还款,
                TransferType.资产间转账 }.Select(o => o.ToString()).ToList();
            _models = models.Where(o => !excludeTypes.Contains(o.TransactionType)).ToList();
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            dgvMonth.DataSource = GetStatisticsTable(true);
            dgvYear.DataSource = GetStatisticsTable(false);
            dgvMonth.ClearSelection();
            dgvYear.ClearSelection();
        }

        private DataTable GetStatisticsTable(bool isMonth)
        {
            string timeUnit = isMonth ? "月" : "年";

            DataTable dtMonth = new DataTable();
            dtMonth.Columns.Add($"{timeUnit}份");
            dtMonth.Columns.Add($"{timeUnit}度总收入", typeof(decimal));
            dtMonth.Columns.Add($"{timeUnit}度总支出", typeof(decimal));
            dtMonth.Columns.Add($"{timeUnit}度盈余", typeof(decimal));

            var monthsData = _models.GroupBy(o => o.Time.ToString(isMonth ? "yyyy-MM" : "yyyy")).OrderByDescending(o => o.Key).ToList();
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
                            dtMonth.Columns.Add(columnName, typeof(decimal));
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
                            dtMonth.Columns.Add(columnName, typeof(decimal));
                        }
                    }
                }

                var row = dtMonth.NewRow();
                dtMonth.Rows.Add(row);
                row[$"{timeUnit}份"] = month.Key;
                var inAmount = monthIn.Sum(o => o.Amount) - monthRefundAmount;
                var outAmount = monthOut.Sum(o => o.Amount) + monthRefundAmount;
                var profit = inAmount + outAmount;

                //避免有时显示为「0.0」
                if (inAmount == 0)
                {
                    inAmount = 0;
                };
                if (outAmount == 0)
                {
                    outAmount = 0;
                }
                if (profit == 0)
                {
                    profit = 0;
                }

                row[$"{timeUnit}度总收入"] = inAmount;
                row[$"{timeUnit}度总支出"] = outAmount;
                row[$"{timeUnit}度盈余"] = profit;
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

        private void FormStatistics_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
        }
    }
}
