using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data;
//reference added for this namespace : System.Data.Linq
using System.Data.Linq.Mapping;
using tradingSoftwareEntities;


namespace tradingSoftwareEntities
{
    [Table(Name="Transactions")]
    public class Transaction
    {
        [Column(IsPrimaryKey=true,CanBeNull=false,IsDbGenerated=true)]
        public int TransactionID { get; set; }

        [Column(Name="Date",CanBeNull = false)]
        public DateTime DateOfTransaction { get; set; }

        [Column(CanBeNull=false)]
        public int ByAccountID { get; set; }
        
        [Column(CanBeNull=false)]
        public int ToAccountID { get; set; }

        [Column(CanBeNull=false)]
        public decimal Amount { get; set; }

        [Column(CanBeNull=true)]
        public string Narration { get; set; }
    }
}
