using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tradingSoftware
{
    class ListViewPurchaseOrder
    {
        public ListViewPurchaseOrder()
        {

        }

        public ListViewPurchaseOrder(string pONo, string pODate, string supplier, string itemGroup, string item1, string quantity, string pricePerUnit)
        {
            PONo = pONo;
            PODate = pODate;
            Supplier = supplier;
            ItemGroup = itemGroup;
            Item1 = item1;
            Quantity = quantity;
            PricePerUnit = pricePerUnit;
        }
        public string PONo { get; set; }
        public string PODate { get; set; }
        public string Supplier { get; set; }
        public string ItemGroup { get; set; }
        public string Item1 { get; set; }
        public string Quantity { get; set; }
        public string PricePerUnit { get; set; }

    }

    class ListViewPurchaseTaxDetails
    {
        public ListViewPurchaseTaxDetails() { }

        public ListViewPurchaseTaxDetails(string v1, string v2,string v3,string v4)
        {
            TaxName = v1;
            TaxPercentage = v2;
            TaxValue = v3;
            TaxType = v4;
        }

        public string TaxName{get;set;}
        public string TaxPercentage { get; set; }
        public string TaxValue { get; set; }
        public string TaxType { get; set; }



    }
}
