using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tradingSoftwareEntities
{
    public class NullValueException: Exception
    {
        public NullValueException():base()
        {  }

        public NullValueException(string errorString): base(errorString)
        {  }
    }
}
