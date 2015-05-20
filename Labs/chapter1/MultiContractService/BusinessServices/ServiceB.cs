// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using BusinessServiceContracts;

namespace BusinessServices
{

    public class ServiceB: IServiceB, IAdmin
    {

        public string AdminOperation1()
        {
            return "Admin Operation1 Invoded.";
        }

        public string AdminOperation2()
        {
            return "Admin Operation2 Invoded.";
        }

        public string Operation3()
        {
            throw new NotImplementedException();
        }
    }

}
