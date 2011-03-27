using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq.Mapping;
using tradingSoftwareEntities;

namespace tradingSoftwareEntities
{
    public class Account
    {
        private int accountId;
        private string accountName;
        private string accountPrintName;
        private int accountGroupId;
        private string addressLine1;
        private string addressLine2;
        private string addressLine3;
        private string city;
        private string state;
        private int pincode;
        private string email;
        private string contactPerson;
        private int telephoneNo;
        private string panNo;

        public int AccountId
        {
            get
            {
                return this.accountId;
            }
            set
            {
                if (value > 0)
                {
                    this.accountId = value;
                }
                else
                {
                    throw new NegativeValueException("Account Id Cannot be Nagative");
                }
            }
        }
        public string AccountName
        {
            get
            {
                return this.accountName;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.accountName = value;
                }
                else
                {
                    throw new NullValueException("Account Name Cannot be blank");
                }
            }
        }
        public string AccountPrintName
        {
            get
            {
                return this.accountPrintName;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.accountPrintName = value;
                }
                else
                {
                    throw new NullValueException("Account Print Name Cannot Be Blank");
                }
            }
        }
        public int AccountGroupId
        {
            get
            {
                return this.accountGroupId;
            }
            set
            {
                if (value > 0)
                {
                    this.accountGroupId = value;
                }
                else
                {
                    throw new NegativeValueException("Account Group Id Cannot Be Nagative");
                }
            }
        }
        public string AddressLine1
        {
            get
            {
                return this.addressLine1;
            }
            set
            {
                this.addressLine1 = value;
            }
        }
        public string AddressLine2
        {
            get
            {
                return this.addressLine2;
            }
            set
            {
                this.addressLine2 = value;
            }
        }
        public string AddressLine3
        {
            get
            {
                return this.addressLine3;
            }
            set
            {
                this.addressLine3 = value;
            }
        }
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
            }
        }
        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }
        public int Pincode
        {
            get
            {
                return this.pincode;
            }
            set
            {
                this.pincode = value;
            }
        }
        public string Email
        { 
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }
        public int TelephoneNo
        {
            get
            {
                return this.telephoneNo;
            }
            set
            {
                this.telephoneNo = value;
            }
        }
        public string PanNo
        {
            get
            {
                return this.panNo;
            }
            set
            {
                this.panNo = value;
            } 
        }
    }
}
