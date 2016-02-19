using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientForRoutingService.HelloIndigoService;

namespace ClientForRoutingService
{
    //160219添加
    class Program
    {

        static void CallHttpRoutingService()
        {
            Service2Client serv2Client = new Service2Client();
            Console.WriteLine("=== test Service2 ===");
            Console.WriteLine(serv2Client.Hello("parm for hello"));
            Console.WriteLine(serv2Client.Hello2("parm for hello2"));

            HelloIndigoServiceClient helloClient = new HelloIndigoServiceClient();
            Console.WriteLine("\r\n=== test HelloIndigoService ===");
            Console.WriteLine(helloClient.HelloIndigo());
        }

        static void Main(string[] args)
        {
            CallHttpRoutingService();
        }
    }
}
