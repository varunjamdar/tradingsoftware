using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tradingSoftwareEntities;

namespace tradingSoftwareEntities
{
    public class ItemObject
    {
        public int itemId;
        public int itemGroupId;
        public String itemName;
        public String itemDesc;
        public int unitId;
        public DateTime openDate;
        public int openStockQty;
        public int openStockValue;
        public int purchasePrice;
        public int salePrice;
        public int mrp;
        public int minimumSalePrice;
        public int insuranceAmount;
        public int hsnCode;
        public String imcoClass;
        public int casNo;

        public int ItemId {
            get
            {
                return this.itemId;
            }
        
            set
            {
                if (value > 0)
                {
                    this.itemId = value;
                }
                else
                {
                    throw new NegativeValueException("Item ID cannot Be negative");
                }
            }
        }
        public int ItemGroupId
        {
            get
            {
                return this.itemGroupId;
            }
            set
            {
                if (value > 0)
                {
                    this.itemGroupId =value;
                }
                else
                {
                    throw new NegativeValueException("Item Group ID Cannot be negative");
                }
            }
        }
        public String ItemName {
            get
            {
                return this.itemName;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.itemName =value;
                }
                else
                {
                    throw new NullValueException("The Item Name cannot be Blank");
                }
            }
        }
        public String ItemDesc {
            get
            {
                return this.itemDesc;
            }
            set
            {
                if (value.Length >= 0)
                {
                    this.itemDesc = value;
                }
                else
                {
                    throw new NullValueException("The Item Description cannot be null");
                }
            }
        }
        public int UnitId {
            get
            {
                return this.unitId;
            }
            set
            {
                if (value > 0)
                {
                    this.unitId = value;
                }
                else
                {
                    throw new NegativeValueException(" Unit ID cannot be negative");
                }
            }
        }
        public DateTime OpenDate { get; set; }
        public int OpenStockQty {
            get
            {
                return this.openStockQty;
            }
            set
            {
                if (value > 0)
                {
                    this.openStockQty = value;
                }
                else
                {
                    throw new NegativeValueException("Open Stock Quantity cannot be negative");
                }
            }
        }
        public int OpenStockValue { get; set; }
        public int PurchasePrice { get; set; }
        public int SalePrice { get; set; }
        public int Mrp { get; set; }
        public int MinimumSalePrice { get; set; }
        public int InsuranceAmount { get; set; }
        public int HsnCode { get; set; }
        public String ImcoClass { get; set; }
        public int CasNo { get; set; }
    }
}
