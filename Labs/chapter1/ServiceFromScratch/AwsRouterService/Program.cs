using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Routing;
using System.Text;
using System.Threading.Tasks;

namespace AwsRouterService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(RoutingService)))
            {
                host.Open();
                Console.WriteLine("Press <ENTER> to terminate Router Host");
                Console.ReadLine();
            }                              

        }
    }
}
