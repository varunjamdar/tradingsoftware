using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tradingSoftware
{
    

    public class SaleItem
    {
        public SaleItem()
        {
            
        }

        public SaleItem(string ig, string i, int q, float ppu, decimal rs)
        {
            this.ItemGroup = ig;
            this.ItemName = i;
            this.Quantity = q;
            this.PricePerUnit = ppu;
            this.Amount = rs;
        }
        public string ItemGroup { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public float PricePerUnit { get; set; }
        public decimal Amount { get; set; }
    }

    public class SaleTax
    {
        public SaleTax()
        {

        }

        public SaleTax(string name, float percentage, float amount, string type)
        {
            TaxName = name;
            this.TaxPercentage = percentage;
            this.TaxAmount = amount;
            this.TaxType = type;
        }

        public string TaxName { get; set; }
        public float TaxPercentage { get; set; }
        public float TaxAmount { get; set; }
        public string TaxType { get; set; }
    }

    public class Challan
    {
        public Challan()
        {

        }

        public int SaleId { get; set; }
        public DateTime DateOfChallan { get; set; }
        public string PaymentMode { get; set; }
        public int LorryReceiptNo { get; set; }
        public string Transporter { get; set; }
        public string Destination { get; set; }

    }

    public class ListViewSale
    {
        public ListViewSale()
        {

        }

        public ListViewSale(string itemGroup, string item1, int quantity, float pricePerUnit)
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

    class ListViewSaleTaxDetails
    {
        public ListViewSaleTaxDetails() { }

        public ListViewSaleTaxDetails(string v1, float v2, float v3, string v4, float TotalAmount)
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

        public string TaxName { get; set; }
        public float TaxPercentage { get; set; }
        public float TaxAmount { get; set; }
        public string TaxType { get; set; }
    }
}