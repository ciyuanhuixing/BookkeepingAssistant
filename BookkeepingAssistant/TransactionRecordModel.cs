using System;
using System.Collections.Generic;
using System.Text;

namespace BookkeepingAssistant
{
    public class TransactionRecordModel
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public bool isIncome { get; set; }
        public decimal Amount { get; set; }
        public string AssetName { get; set; }
        public decimal AssetValue { get; set; }
        public string TransactionType { get; set; }
        public string RefundLinkId { get; set; }
        public string Remark { get; set; }
        public int? DeleteLinkId { get; set; }
    }
}
