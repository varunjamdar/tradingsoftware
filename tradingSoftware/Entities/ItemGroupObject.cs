using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tradingSoftwareEntities;

namespace tradingSoftwareEntities
{
    [Serializable]
    public class ItemGroupObject
    {
        private int itemGroupId;
        private string itemGroupName;
        private string itemGroupDescription;

        public int ItemGroupID 
        {
            get
            {
                return this.itemGroupId;
            }
            set
            {

                if (value >= 0)
                    this.itemGroupId = value;
                else
                    throw new NegativeValueException("Item Group Id cannot be negative.");
            }
        }
        public string ItemGroupName
        {
            get
            {
                return this.itemGroupName;
            }
            set
            {
                if (value.Length > 0)
                    this.itemGroupName = value;
                else
                    throw new NullValueException("Item Group Name cannot ne empty string.");
            }
        }
        public string ItemGroupDescription
        {
            get
            {
                return this.itemGroupDescription;
            }
            set
            {
                if (value.Length > 0)
                    this.itemGroupDescription = value;
                else
                    throw new NullValueException("Item Group Description cannot ne empty string.");
            }
        }
    }
}
