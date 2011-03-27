using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq.Mapping;
using tradingSoftwareEntities;

namespace tradingSoftwareEntities
{
    public class LedgerRow
    {
        public int TransactionID { get; set; }
        public string DateOfTransaction { get; set; }
        public string TransactionDetails { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public string Balance { get; set; }
    }
}
