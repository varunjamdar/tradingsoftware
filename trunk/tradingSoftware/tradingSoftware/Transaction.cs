using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tradingSoftware
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public int ByAccountID { get; set; }
        public int ToAccountID { get; set; }
        public decimal Amount { get; set; }
        public string Narration { get; set; }
    }
}
