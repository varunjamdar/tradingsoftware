using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq.Mapping;
using tradingSoftwareEntities;

namespace tradingSoftwareEntities
{
    public class Tax
    {
        public int taxId;
        public string taxName;
        public double value;

        public int TaxID
        {
            get
            {
                return this.taxId;
            }
            set
            {
                if (value > 0)
                {
                    this.taxId = value;
                }
                else
                {
                    throw new NegativeValueException("Tax ID Cannot be negative.");
                }
            }
        }
        public string TaxName
        {
            get
            {
                return this.taxName;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.taxName = value;
                }
                else
                {
                    throw new NullValueException("Tax Name cannot be blank.");
                }
            }
        }
        public double Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (value > 0d)
                    this.value = value;
                else
                    throw new NegativeValueException("Tax Value cannot be negative.");
            }
        }
    }
}
