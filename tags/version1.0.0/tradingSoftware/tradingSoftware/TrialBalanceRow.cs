using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tradingSoftware
{
    public class TrialBalanceRow
    {
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
    }
}
