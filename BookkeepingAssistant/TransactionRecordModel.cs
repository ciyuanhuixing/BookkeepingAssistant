using System;
using System.Collections.Generic;
using System.Text;

namespace BookkeepingAssistant
{
    public class TransactionRecordModel
    {
        public DateTime Time { get; set; }
        public bool isIncome { get; set; }
        public decimal Amount { get; set; }
        public string AssetName { get; set; }
        public decimal AssetValue { get; set; }
        public string TransactionType { get; set; }
    }
}
