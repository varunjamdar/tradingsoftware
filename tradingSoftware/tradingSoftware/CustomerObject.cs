using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tradingSoftware
{
    public class CustomerObject
    {
        private int customerId;
        private int accountId;
        private string customerCompany;
        private string contactPerson;
        private string addline1;
        private string addline2;
        private string addline3;
        private string city;
        private string pin;
        private string state;
        private string phoneno1;
        private string phoneno2;
        private string website;
        private string emailId;
        private string fax;
        private string vatgst;
        private string tinno;
        private DateTime vstgstdate;
        private string cstno;
        private DateTime cstdate;
        private string panno;
        private string servicetaxno;
        private string creditCapacity;
        private string rating;
        private string businessType;


        public int CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                if (value <= 0)
                    throw new NegativeValueException("Supplier Id Cannot Be Negative or 0");
                else
                    customerId = value;
            }
        }

        public int AccountId
        {
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

        public string CustomerCompany
        {
            get
            {
                return customerCompany;
            }
            set
            {
                if (value.Length <= 0)
                    throw new NullValueException("Please Enter the Company Name");
                else
                    customerCompany = value;
            }
        }

        public string ContactPerson
        {
            get
            {
                return contactPerson;
            }
            set
            {
                contactPerson = value;
            }
        }

        public string AddLine1
        {
            get
            {
                return this.addline1;
            }
            set
            {
                this.addline1 = value;
            }
        }
        public string AddLine2
        {
            get
            {
                return this.addline2;
            }
            set
            {
                this.addline2 = value;
            }
        }
        public string AddLine3
        {
            get
            {
                return this.addline3;
            }
            set
            {
                this.addline3 = value;
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
        public string Pin
        {
            get
            {
                return pin;
            }
            set
            {
                pin = value;
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

        public string PhoneNo1
        {
            get
            {
                return this.phoneno1;
            }
            set
            {
                this.phoneno1 = value;
            }
        }
        public string PhoneNo2
        {
            get
            {
                return this.phoneno2;
            }
            set
            {
                this.phoneno2 = value;
            }
        }
        public string Website
        {
            get
            {
                return this.website;
            }
            set
            {
                this.website = value;
            }
        }
        public string EmailId
        {
            get
            {
                return this.emailId;
            }
            set
            {
                this.emailId = value;
            }
        }
        public string Fax
        {
            get
            {
                return this.fax;
            }
            set
            {
                this.fax = value;
            }
        }
        public string VatGst
        {
            get
            {
                return this.vatgst;
            }
            set
            {
                this.vatgst = value;
            }
        }
        public string TinNo
        {
            get
            {
                return this.tinno;
            }
            set
            {
                this.tinno = value;
            }
        }
        public DateTime VatGstDate
        {
            get
            {
                return this.vstgstdate;
            }
            set
            {
                if (value == null)
                {
                    this.vstgstdate = DateTime.MinValue;
                }
                else
                {
                    this.vstgstdate = value;
                }
            }
        }
        public string CstNo
        {
            get
            {
                return this.cstno;
            }
            set
            {
                this.cstno = value;
            }
        }
        public DateTime CstDate
        {
            get
            {
                return this.cstdate;
            }
            set
            {
                if (value == null)
                {
                    this.cstdate = DateTime.MinValue;
                }
                else
                {
                    this.cstdate = value;
                }
            }
        }
        public string PanNo
        {
            get
            {
                return this.panno;
            }
            set
            {
                if (value.Length <= 0)
                {
                    throw new NullValueException("PAN Number cannot be blank");
                }
                else
                {
                    this.panno = value;
                }
            }
        }
        public string ServiceTaxNo
        {
            get
            {
                return this.servicetaxno;
            }
            set
            {
                if (value.Length <= 0)
                {
                    throw new NullValueException("Service Tax No. cannot be null");
                }
                else
                {
                    this.servicetaxno = value;
                }
            }
        }

        public string CreditCapacity
        {
            get
            {
                return creditCapacity;
            }
            set
            {
                creditCapacity = value;
            }
        }

        public string Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
            }
        }

        public string BusinessType
        {
            get
            {
                return businessType;
            }
            set
            {
                businessType = value;
            }
        }
    }
}
