using System;
using System.Collections.Generic;
using System.Text;

namespace BookkeepingAssistant
{
    public class TransactionRecord
    {
        public DateTime Time { get; set; }
        public bool isIncome { get; set; }
        public int Amount { get; set; }
        public string AssetName { get; set; }
        public string TransactionType { get; set; }
    }
}
