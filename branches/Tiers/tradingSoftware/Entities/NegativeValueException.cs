using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tradingSoftwareEntities
{
    public class NegativeValueException : Exception
    {
        public NegativeValueException() : base()
        { }

        public NegativeValueException(string msg) : base(msg)
        { }
    }
}
