﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq.Mapping;
using tradingSoftwareEntities;

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
