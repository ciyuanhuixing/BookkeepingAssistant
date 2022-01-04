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

            List<MonthData> monthDatas = new List<MonthData>();
            var monthsData = _models.GroupBy(o => o.Time.ToString(isMonth ? "yyyy-MM" : "yyyy")).OrderByDescending(o => o.Key).ToList();
            foreach (var month in monthsData)
            {
                MonthData monthData = new MonthData();
                monthDatas.Add(monthData);
                monthData.Name = month.Key;

                var monthIn = month.Where(o => o.isIncome).ToList();
                var monthOut = month.Where(o => !o.isIncome).ToList();

                var monthInTypes = monthIn.GroupBy(o => o.TransactionType).ToList();
                var monthOutTypes = monthOut.GroupBy(o => o.TransactionType).ToList();

                foreach (var inType in monthInTypes)
                {
                    var inTypeAmount = inType.Sum(o => o.Amount);
                    var typeRefundAmount = inType.Where(o => !string.IsNullOrWhiteSpace(o.RefundLinkId)).Sum(o => o.Amount);
                    if (typeRefundAmount > 0)
                    {
                        inTypeAmount -= typeRefundAmount;
                    }
                    if (inTypeAmount != 0)
                    {
                        string columnName = $"{inType.Key}-收";
                        monthData.InTypesAmount.Add(columnName, inTypeAmount);
                    }
                }
                foreach (var outType in monthOutTypes)
                {
                    var outTypeAmount = outType.Sum(o => o.Amount);
                    var refundLinkModels = outType.Where(o => !string.IsNullOrWhiteSpace(o.RefundLinkId)).ToList();
                    foreach (var rlm in refundLinkModels)
                    {
                        var ids = rlm.RefundLinkId.Split(',');
                        foreach (var id in ids)
                        {
                            if (!string.IsNullOrWhiteSpace(id))
                            {
                                var refund = _models.Single(o => o.Id.ToString() == id);
                                outTypeAmount += refund.Amount;
                            }
                        }
                    }

                    if (outTypeAmount != 0)
                    {
                        string columnName = $"{outType.Key}-支";
                        monthData.OutTypesAmount.Add(columnName, outTypeAmount);
                    }
                }
            }

            string timeUnit = isMonth ? "月" : "年";

            DataTable dtMonth = new DataTable();
            dtMonth.Columns.Add($"{timeUnit}份");
            dtMonth.Columns.Add($"{timeUnit}度总收", typeof(decimal));
            dtMonth.Columns.Add($"{timeUnit}度总支", typeof(decimal));
            dtMonth.Columns.Add($"{timeUnit}度盈余", typeof(decimal));

            foreach (var md in monthDatas)
            {
                foreach (var typeAndAmount in md.InTypesAmount.OrderByDescending(o=>o.Value))
                {
                    if (!dtMonth.Columns.Contains(typeAndAmount.Key))
                    {
                        dtMonth.Columns.Add(typeAndAmount.Key, typeof(decimal));
                    }
                }
            }
            foreach (var md in monthDatas)
            {
                foreach (var typeAndAmount in md.OutTypesAmount.OrderBy(o => o.Value))
                {
                    if (!dtMonth.Columns.Contains(typeAndAmount.Key))
                    {
                        dtMonth.Columns.Add(typeAndAmount.Key, typeof(decimal));
                    }
                }
            }

            foreach (var md in monthDatas)
            {
                var row = dtMonth.NewRow();
                dtMonth.Rows.Add(row);
                row[$"{timeUnit}份"] = md.Name;
                var inAmount = md.InTypesAmount.Sum(o => o.Value);
                var outAmount = md.OutTypesAmount.Sum(o => o.Value);
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

                row[$"{timeUnit}度总收"] = inAmount;
                row[$"{timeUnit}度总支"] = outAmount;
                row[$"{timeUnit}度盈余"] = profit;
                foreach (var typeAndAmount in md.InTypesAmount)
                {
                    row[typeAndAmount.Key] = typeAndAmount.Value;
                }
                foreach (var typeAndAmount in md.OutTypesAmount)
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

    public class MonthData
    {
        public string Name { get; set; }
        public Dictionary<string, decimal> InTypesAmount { get; set; } = new Dictionary<string, decimal>();
        public Dictionary<string, decimal> OutTypesAmount { get; set; } = new Dictionary<string, decimal>();
    }
}
