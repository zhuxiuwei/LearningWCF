using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Client.ServiceReference1;
using MyService;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceClient sc = new ServiceClient();
            MyResult[] res = sc.GetResult(300000);
            //foreach (var r in res)
            //{
            //    Console.WriteLine(r.ID);
            //}
            Console.WriteLine(res.Count());
            Console.WriteLine("Press <ENTER> to terminate Client.");
            Console.ReadLine();
        }
    }
}
