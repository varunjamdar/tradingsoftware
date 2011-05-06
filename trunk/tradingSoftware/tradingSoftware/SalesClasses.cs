using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tradingSoftware
{
    //public class Sale
    //{
    //    public List<SaleItem> SaleItems;
    //    public List<SaleTax> SaleTaxes;
        

    //    public Sale()
    //    {

    //    }
    //}

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

        public string TaxName { get; set; }
        public float TaxPercentage { get; set; }
        public float TaxAmount { get; set; }
        public string TaxType { get; set; }
    }
}