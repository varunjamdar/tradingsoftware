using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tradingSoftware
{
    public class Sale
    {
        public List<SaleItem> SaleItems;
        public List<SaleTax> SaleTaxes;
        

        public Sale()
        {

        }
    }

    public class SaleItem
    {
        public SaleItem()
        {
            
        }

        public SaleItem( int q, float ppu, decimal rs)
        {
            Quantity = q;
            PricePerUnit = ppu;
            this.Rs = rs;
        }
        public string ItemGroup { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public float PricePerUnit { get; set; }
        public decimal Rs { get; set; }
    }

    public class SaleTax
    {
        public SaleTax()
        {

        }
    }
}