using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace tradingSoftware
{
    public class ItemObject
    {
        private int itemId;
        private String itemCode;
        private String itemGroup;
        private string itemName;
        private string itemDescription;
        private String unit;
        private DateTime openDate;
        private int openStockQty;
        private float openStockValue;
        private float purchasePrice;
        private float salePrice;
        private float mrp;
        private float minimumSalePrice;
        private float insuranceAmount;
        private string hsnCode;
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

        public String ItemCode {
            get
            {
                return this.itemCode;
            }
            set
            {
                if (value.Length > 0)
                {
                    itemCode = value;
                }
                else
                {
                    throw new NullValueException("Item Code Cannot Be blank");
                }
            }
        }

        public String ItemGroup
        {
            get
            {
                return this.itemGroup;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.itemGroup =value;
                }
                else
                {
                    throw new NullValueException("ItemGroup Cant be blank");
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
        public String Unit
        {
            get
            {
                return this.unit;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.unit = value;
                }
                else
                {
                    throw new NullValueException("unit cannot be blank");
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
        public float OpenStockValue
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
        public float PurchasePrice
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
        public float SalePrice
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
        public float Mrp
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
        public float MinimumSalePrice
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
        public float InsuranceAmount
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
        public string HsnCode
        {
            get
            {
                return this.hsnCode;
            }
            set
            {
                this.hsnCode = value;
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
