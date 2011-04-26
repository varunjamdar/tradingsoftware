using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace tradingSoftware
{
    public class CompanyObject
    {
        private int companyId;
        private string companyName;
        private string companyPrintName;
        private DateTime fyStartDate;
        private DateTime booksCommencing;
        private string addline1;
        private string addline2;
        private string addline3;
        private string city;
        private int pin;
        private string state;
        private string country;
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
        private string imagepath;

        public int CompanyId {
            get
            {
                return this.companyId;
            }
            set
            {
                if (companyId < 0)
                {
                    throw new NegativeValueException("Company ID cannot be negative");
                }
                else
                {
                    this.companyId = value;
                }
            }
        }
        public string CompanyName {
            get
            {
                return this.companyName;
            }
            set
            {
                if (value.Length <= 0)
                {
                    throw new NullValueException("Company Name cannot be null");
                }
                else
                {
                    this.companyName = value;
                }
            }             
        }
        public string CompanyPrintName {
            get
            {
                return this.companyPrintName; 
            }
            set
            {
                if (value.Length <= 0)
                {
                    throw new NullValueException("Company Print Name cannot be null");
                }
                else
                {
                    this.companyPrintName = value;
                }
            }
        }
        public DateTime FyStartDate {
            get
            {
                return this.fyStartDate;
            }
            set
            {
                this.fyStartDate = value;
            }
        }
        public DateTime BooksCommencing {
            get
            {
                return this.booksCommencing;
            }
            set
            {
                this.booksCommencing = value;
            }
        }
        public string AddLine1 {
            get
            {
                return this.addline1;
            }
            set
            {
                if (value.Length <= 0)
                {
                    throw new NullValueException("Address cannot be null");
                }
                else
                {
                    this.addline1 = value;
                }
            }
        }
        public string AddLine2 {
            get
            {
                return this.addline2;
            }
            set
            {
                this.addline2 = value;
            }
        }
        public string AddLine3 {
            get
            {
                return this.addline3;
            }
            set
            {
                this.addline3 = value;
            }
        }
        public string City {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
            }
        }
        public int Pin {
            get
            {
                return this.pin;
            }
            set
            {
                if (value <= 0)
                {
                    throw new NegativeValueException("Pin Code cannot be null");
                }
                else
                {
                    this.pin = value;
                }
            }
        }
        public string State {
            get
            {
                return this.state;
            }
            set
            {
                if (value.Length <= 0)
                {
                    throw new NullValueException("State name cannot be null");
                }
                else
                {
                    this.state = value;
                }
            }
        }
        public string Country {
            get
            {
                return this.country;
            }
            set
            {
                if (value.Length <= 0)
                {
                    throw new NullValueException("Country cannot be null");
                }
                else
                {
                    this.country = value;
                }
            }
        }
        public string PhoneNo1 {
            get
            {
                return this.phoneno1;
            }
            set
            {
                if (value.Length <= 0)
                {
                    throw new NullValueException("Phone No cannot be blank");
                }
                else
                {
                    this.phoneno1 = value;
                }
            }
        }
        public string PhoneNo2 {
            get
            {
                return this.phoneno2;
            }
            set
            {
                this.phoneno2 = value;
            }
        }
        public string Website {
            get
            {
                return this.website;
            }
            set
            {
                this.website = value;
            }
        }
        public string EmailId {
            get
            {
                return this.emailId;
            }
            set
            {
                this.emailId = value;
            }
        }
        public string Fax {
            get
            {
                return this.fax;
            }
            set
            {
                this.fax = value;
            }
        }
        public string VatGst {
            get
            {
                return this.vatgst;
            }
            set
            {
                this.vatgst = value;
            }
        }
        public string TinNo {
            get
            {
                return this.tinno;
            }
            set
            {
                this.tinno = value;
            }
        }
        public DateTime VatGstDate {
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
        public string CstNo {
            get
            {
                return this.cstno;
            }
            set
            {
                this.cstno = value;
            }
        }
        public DateTime CstDate {
            get
            {
                return this.cstdate;
            }
            set
            {
                if (value==null)
                {
                    this.cstdate = DateTime.MinValue;
                }
                else
                {
                    this.cstdate = value;
                }                
            }
        }
        public string PanNo {
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
        public string ServiceTaxNo {
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
        public string ImagePath {
            get
            {
                return this.imagepath;
            }
            set
            {
                if (value.Length <= 0)
                {
                    throw new NullValueException("Company Image Has to be selected");
                }
                else
                {
                    this.imagepath = value;
                }
            }
        }
    }
}
