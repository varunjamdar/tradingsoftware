using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace tradingSoftware
{
    public class NullValueException: Exception
    {
        public NullValueException():base()
        {  }

        public NullValueException(string errorString): base(errorString)
        {  }
    }
}
