﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelloIndigo
{
    public class HelloIndigoService : IHelloIndigoService
    {
        public string HelloIndigo()
        {
            return "hello Indigo!";
        }
    }
}
