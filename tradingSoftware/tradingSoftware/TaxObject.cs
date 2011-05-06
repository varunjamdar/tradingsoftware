using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tradingSoftware
{
    public class TaxObject
    {
        private int taxId;
        private string taxName;
        private float percentage;

        public int TaxId {
            get
            {
                return taxId;
            }
            set
            {
                if (value <= 0)
                    throw new NegativeValueException("Tax ID cannot be Negative Or 0");
                else
                    taxId = value;
            }
        }

        public string TaxName {
            get
            {
                return taxName;
            }
            set
            {
                if (taxName.Length <= 0)
                    throw new NullValueException("Tax Name Cannot Be NULL");
                else
                    taxName = value;
            }
        }
        public float Percentage {
            get
            {
                return percentage;
            }
            set
            {
                percentage = value;
            }
        }
    }
}
