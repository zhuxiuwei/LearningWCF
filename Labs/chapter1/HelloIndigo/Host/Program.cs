﻿// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

/**
 * 20150518 zhuxw 
 */

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(HelloIndigoService)))
            {
                host.Open();
                Console.WriteLine("Press <Enter> to Terminate Server.");
                Console.ReadLine();
            }
        }
    }
}
