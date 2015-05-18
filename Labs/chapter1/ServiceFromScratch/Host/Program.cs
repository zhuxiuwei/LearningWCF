using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using HelloIndigo;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(HelloIndigoService), new Uri("http://localhost:8000/HelloIndigo")))
            {
                host.AddServiceEndpoint(typeof(HelloIndigoService), new BasicHttpBinding(), "HelloIndigoService22");
                host.Open();    // Service channel craeted
                Console.WriteLine("Press <ENTER> to terminate the service host");
                Console.ReadLine();
            }   // will call host.Close() automatically by end of using.
        }
    }
}
