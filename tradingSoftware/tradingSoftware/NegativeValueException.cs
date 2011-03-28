using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace tradingSoftware
{
    public class NegativeValueException : Exception
    {
        public NegativeValueException() : base()
        { }

        public NegativeValueException(string msg) : base(msg)
        { }
    }
}
