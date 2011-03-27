using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using tradingSoftwareEntities;

namespace tradingSoftwareEntities
{
    public class Unit
    {
        private int unitId;
        private string unitName;
        private string unitPrintName;
        private string subUnitName;
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
                    this.unitId = value;
                else
                    throw new NegativeValueException("UnitID cannot be negative.");
            }
        }
        public string UnitName
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
        public string UnitPrintName
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
        public string SubUnitName
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
