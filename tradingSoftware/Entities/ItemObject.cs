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
        public String casNo;

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
        public int OpenStockValue {
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
        public int PurchasePrice {
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
        public int SalePrice {
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
        public int Mrp {
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
        public int MinimumSalePrice {
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
        public int InsuranceAmount {
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
        public int HsnCode {
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
        public String ImcoClass {
            get
            {
                return this.imcoClass;
            }
            set
            {
                this.imcoClass = value;
            }
        }
        public String CasNo {
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
