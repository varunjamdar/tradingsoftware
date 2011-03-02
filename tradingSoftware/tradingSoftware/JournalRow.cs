using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tradingSoftware
{
    public class JournalRow
    {   // A class to simulate expected DataGrid Rows
	
        private DateTime date;

        public string DateOfTransaction
        { 
            get
            {
                return date.ToShortDateString();
            }
            set
            {
                DateTime dt;
                DateTime.TryParse(value.ToString(), out dt);
                date = dt;
            }
        }
        public string DebitOrCredit { get; set; }
        public string TransactionDetails { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}
