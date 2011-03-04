using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tradingSoftware
{
    public class JournalRow
    {   // A class to simulate expected DataGrid Rows
 
        public int TransactionID { get; set; }
        public string DateOfTransaction { get; set; }
        public string DebitOrCredit { get; set; }
        public string TransactionDetails { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public string Narration { get; set; }
    }
}
