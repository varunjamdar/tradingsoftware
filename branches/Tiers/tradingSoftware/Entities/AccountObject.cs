using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tradingSoftwareEntities;

namespace tradingSoftwareEntities
{
    public class AccountObject
    {
        public int accountId;
        public String accountName;
        public String accountPrintName;
        public int accountGroupId;
        public String addressLine1;
        public String addressLine2;
        public String addressLine3;
        public String city;
        public String state;
        public int pincode;
        public String email;
        public String contactPerson;
        public int telephoneNo;
        public int panNo;

        public int AccountId {
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
        public String AccountName {
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
        public String AccountPrintName {
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
        public int AccountGroupId {
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
        public String AddressLine1 {
            get
            {
                return this.addressLine1;
            }
            set
            {
                this.addressLine1 = value;
            }
        }
        public String AddressLine2 {
            get
            {
                return this.addressLine2;
            }
            set
            {
                this.addressLine2 = value;
            }
        }
        public String AddressLine3 {
            get
            {
                return this.addressLine3;
            }
            set
            {
                this.addressLine3 = value;
            }
        }
        public String City {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
            }
        }
        public String State {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }
        public int Pincode {
            get
            {
                return this.pincode;
            }
            set
            {
                this.pincode = value;
            }
        }
        public String Email { 
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }
        public int TelephoneNo {
            get
            {
                return this.telephoneNo;
            }
            set
            {
                this.telephoneNo = value;
            }
        }
        public int PanNo {
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
