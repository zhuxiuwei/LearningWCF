using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using MyService;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ServiceImpl)))
            {
                host.Open();    // Service channel craeted
                Console.WriteLine("Press <ENTER> to terminate the service host");
                Console.ReadLine();
            } 
        }
    }
}
