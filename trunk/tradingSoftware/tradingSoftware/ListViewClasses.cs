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

        public ListViewPurchaseOrder(string itemGroup, string item1, int quantity, float pricePerUnit)
        {
            ItemGroup = itemGroup;
            Item1 = item1;
            Quantity = quantity;
            PricePerUnit = pricePerUnit;
            Rs = quantity * pricePerUnit;
        }
        public string ItemGroup { get; set; }
        public string Item1 { get; set; }
        public int Quantity { get; set; }
        public float PricePerUnit { get; set; }
        public float Rs { get; set; }

    }

    class ListViewPurchaseTaxDetails
    {
        public ListViewPurchaseTaxDetails() { }

        public ListViewPurchaseTaxDetails(string v1, float v2,float v3,string v4,float TotalAmount)
        {
            TaxName = v1;
            TaxPercentage = v2;

            if (v2 == 0)
            {
                //Go by Tax Value not percentage
                if (v4 == "Exclusive")
                {
                    TaxAmount = v3;//finging the percentage
                }

                if (v4 == "Inclusive")
                {
                    TaxAmount = v3;
                }
            }
            else
            {
                //Go by Percentage
                if (v4 == "Exclusive")
                {
                    TaxAmount = (TotalAmount / 100) * v2;//finging the percentage
                }

                if (v4 == "Inclusive")
                {
                    TaxAmount = (TotalAmount / 100) * v2;
                }
            }
            //TaxAmount = v3;
            TaxType = v4;
        }

        public string TaxName{get;set;}
        public float TaxPercentage { get; set; }
        public float TaxAmount { get; set; }
        public string TaxType { get; set; }



    }
}
