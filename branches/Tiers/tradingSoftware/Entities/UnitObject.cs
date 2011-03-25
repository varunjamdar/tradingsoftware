using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tradingSoftwareEntities;

namespace tradingSoftwareEntities
{
    public class UnitObject
    {
        private int unitId;
        private String unitName;
        private String unitPrintName;
        private String subUnitName;
        private int conversion;

        public int UnitID
        {
            get
            {
                return this.unitId;
            }
            set
            {
                if (value >= 0)
                    this.unitId = unitId;
                else
                    throw new NegativeValueException("UnitID cannot be negative.");
            }
        }
        public String UnitName
        {
            get
            {
                return this.unitName;
            }
            set
            {
                if (value.Length > 0)
                    this.unitName = value;
                else
                    throw new NullValueException("Unit Name cannot be empty string.");
            }
        }
        public String UnitPrintName
        {
            get
            {
                return this.unitPrintName;
            }
            set
            {
                if (value.Length > 0)
                    this.unitPrintName = value;
                else
                    throw new NullValueException("Unit print Name cannot be empty string.");
            }
        }
        public String SubUnitName
        {
            get
            {
                return this.subUnitName;
            }
            set
            {
                if (value.Length > 0)
                    this.subUnitName = value;
                else
                    throw new NullValueException("Subunit Name cannot be empty string.");
            }
        }
        public int Conversion
        {
            get 
            {
                return this.conversion;
            }
            set
            {
                if (value > 0)
                    this.conversion = value;
                else
                    throw new NegativeValueException("Value cannot be negative.");
            }
        } 
    }
}
