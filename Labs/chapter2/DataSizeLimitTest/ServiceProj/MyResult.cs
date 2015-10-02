using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyService
{
    public class MyResult
    {
        [DataMember]
        public long ID { get; set; }
    }
}