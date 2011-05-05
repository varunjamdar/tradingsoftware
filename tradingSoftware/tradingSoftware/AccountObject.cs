using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tradingSoftware
{
    public class AccountObject
    {
        private int accountId;
        private string accountName;
        private string accountPrintName;
        private string accountGroup;
        private string addline1;
        private string addline2;
        private string addline3;
        private string city;
        private string pin;
        private string state;
        private string contactPerson;
        private string email;
        private string phoneNo;
        private string itPanNo;

        public int AccountId {
            get
            {
                return accountId;
            }

            set
            {
                if (value <= 0)
                    throw new NegativeValueException("Account Id cannot be negative or 0");
                else
                    accountId = value;
            }
        }
        public string AccountName {
            get
            {
                return accountName;
            }
            set
            {
                if (value.Length <= 0)
                {
                    throw new NullValueException("Account Name Cannot Be Null");
                }
                else
                {
                    accountName = value;
                }
            }
        }
        public string AccountPrintName {
            get
            {
                return accountPrintName;
            }
            set
            {
                if (value.Length <= 0)
                {
                    throw new NullValueException("Account Print Name Cannot Be Null");
                }
                else
                {
                    accountPrintName = value;
                }
            }
        }
        public string AccountGroup {
            get
            {
                return accountGroup;
            }
            set
            {
                if (value.Length <= 0)
                {
                    throw new NullValueException("Account Group Has To be selected");
                }
                else
                {
                    accountGroup = value;
                }
            }
        }
        public string AddLine1 {
            get
            {
                return addline1;
            }
            set
            {
                addline1 = value;
            }
        }
        public string AddLine2 {
            get
            {
                return addline2;
            }
            set
            {
                addline2 = value;
            }
        }
        public string AddLine3 {
            get
            {
                return addline3;
            }
            set
            {
                addline3 = value;
            }
        }
        public string City {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }
        public string Pin {
            get
            {
                return pin;
            }
            set
            {
                pin = value;
            }
        }
        public string State {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
        public string ContactPerson {
            get
            {
                return contactPerson;
            }
            set
            {
                contactPerson = value;
            }
        }
        public string Email {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string PhoneNo {
            get
            {
                return phoneNo;
            }
            set
            {
                phoneNo = value;
            }
        }
        public string ItPanNo {
            get
            {
                return itPanNo;
            }
            set
            {
                itPanNo = value;
            }
        }
    }
}
