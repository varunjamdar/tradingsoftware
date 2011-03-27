using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq.Mapping;
using tradingSoftwareEntities;

namespace tradingSoftwareEntities
{
    public class Item
    {
        private int itemId;
        private int itemGroupId;
        private string itemName;
        private string itemDescription;
        private int unitId;
        private DateTime openDate;
        private int openStockQty;
        private int openStockValue;
        private int purchasePrice;
        private int salePrice;
        private int mrp;
        private int minimumSalePrice;
        private int insuranceAmount;
        private int hsnCode;
        private string imcoClass;
        private string casNo;

        public int ItemID
        {
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
        public int ItemGroupID
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
        public string ItemName
        {
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
                    throw new NullValueException("The Item Name cannot be blank");
                }
            }
        }
        public string ItemDescription
        {
            get
            {
                return this.itemDescription;
            }
            set
            {
                if (value.Length >= 0)
                {
                    this.itemDescription = value;
                }
                else
                {
                    throw new NullValueException("The Item Description cannot be null");
                }
            }
        }
        public int UnitID
        {
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
        public DateTime OpenDate
        {
            get
            {
                return this.openDate;
            }
            set
            {
                this.openDate = value;
            }
        }
        public int OpenStockQuantity
        {
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
                    throw new NegativeValueException("Open Stock Quantity cannot be negative.");
                }
            }
        }
        public int OpenStockValue
        {
            get
            {
                return this.openStockValue;
            }
            set
            {
                if (value > 0)
                {
                    this.openStockValue = value;
                }
                else
                {
                    throw new NegativeValueException("Open Stock Value cannot be negative");
                }
            }
        }
        public int PurchasePrice
        {
            get
            {
                return this.purchasePrice;
            }
            set
            {
                if (value > 0)
                {
                    this.purchasePrice = value;
                }
                else
                {
                    throw new NegativeValueException("Purchase Price cannot be negative");
                }
            }
        }
        public int SalePrice
        {
            get
            {
                return this.salePrice;
            }
            set
            {
                if (value > 0)
                {
                    this.salePrice = value;
                }
                else
                {
                    throw new NegativeValueException("Sale Price cannot be negative");
                }
            }
        }
        public int Mrp
        {
            get
            {
                return this.mrp;
            }
            set
            {
                if (value > 0)
                {
                    this.mrp = value;
                }
                else
                {
                    throw new NegativeValueException("MRP of an Item cannot be negative");
                }
            }
        }
        public int MinimumSalePrice
        {
            get
            {
                return this.minimumSalePrice;
            }
            set
            {
                if (value > 0)
                {
                    this.minimumSalePrice = value;
                }
                else
                {
                    throw new NegativeValueException("Minimum Sale Price cannot be negative");
                }
            }
        }
        public int InsuranceAmount
        {
            get
            {
                return this.insuranceAmount;
            }
            set
            {
                if (value > 0)
                {
                    this.insuranceAmount = value;
                }
                else
                {
                    throw new NegativeValueException("Insurance Amount cannot be negative");
                }
            }
        }
        public int HsnCode
        {
            get
            {
                return this.hsnCode;
            }
            set
            {
                if (value > 0)
                {
                    this.hsnCode = value;
                }
                else
                {
                    throw new NegativeValueException("HSN Code cannot be negative");
                }
            }
        }
        public string IMCOClass
        {
            get
            {
                return this.imcoClass;
            }
            set
            {
                this.imcoClass = value;
            }
        }
        public string CasNo
        {
            get
            {
                return this.casNo;
            }
            set
            {
                this.casNo = value;
            }
        }
    }
}
