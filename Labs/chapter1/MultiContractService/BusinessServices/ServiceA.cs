// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using BusinessServiceContracts;


namespace BusinessServices
{

    public class ServiceA : IServiceA, IAdmin
    {


        public string AdminOperation1()
        {
            return "Admin Operation1 Invoded.";
        }

        public string AdminOperation2()
        {
            return "Admin Operation2 Invoded.";
        }

        public string Operation1()
        {
            return "ServiceA Operation1 Invoded.";
        }

        public string Operation2()
        {
            return "ServiceA Operation2 Invoded.";
        }
    }

}

