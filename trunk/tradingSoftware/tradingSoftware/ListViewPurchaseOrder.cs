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

        public ListViewPurchaseOrder(string pONo, string pODate, string manufacturer, string itemGroup,string item1, string quantity, string pricePerUnit)
        {
            PONo = pONo;
            PODate = pODate;
            Manufacturer = manufacturer;
            ItemGroup = itemGroup;
            Item1 = item1;
            Quantity=quantity;
            PricePerUnit=pricePerUnit;
        }
        public string PONo { get; set; }
        public string PODate { get; set; }
        public string Manufacturer { get; set; }
        public string ItemGroup { get; set; }
        public string Item1 { get; set; }
        public string Quantity { get; set; }
        public string PricePerUnit { get; set; }

    }
}
