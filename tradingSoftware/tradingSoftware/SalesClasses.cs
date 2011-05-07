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
}