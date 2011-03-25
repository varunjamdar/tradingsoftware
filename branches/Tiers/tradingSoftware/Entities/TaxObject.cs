using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tradingSoftwareEntities;

namespace tradingSoftwareEntities
{
    public class TaxObject
    {
        public int taxId;
        public String taxName;
        public double value;

        public int TaxId {
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
                    throw new NegativeValueException("Tax ID Cannot be negative");
                }
            }
        }
        public String TaxName {
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
                    throw new NullValueException("Tax Name cannot be blank");
                }
            }
        }
        public double Value {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }
}
