using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tradingSoftware
{
    public class PhoneNoErrorException:Exception
    {
        public PhoneNoErrorException() : base()
        { }

        public PhoneNoErrorException(string msg) : base(msg)
        { }
    }
}
