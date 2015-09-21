using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            
            EndpointAddress ep = new EndpointAddress("http://localhost:8000/HelloIndigo/HelloIndigoService22");
            
            //方法1: normal way - 用client工程里定义好的service proxy
            IHelloIndigoService proxy = ChannelFactory<IHelloIndigoService>.CreateChannel(new BasicHttpBinding(), ep);
            string s = proxy.HelloIndigo();
            Console.WriteLine("method1: " + s);

            //方法2: （2015-09-21新加） 直接用service interface。这样的话需要在client project里引入HelloIndigo project。
            HelloIndigo.IHelloIndigoService proxy2 = ChannelFactory<HelloIndigo.IHelloIndigoService>.CreateChannel(new BasicHttpBinding(), ep);
            s = proxy2.HelloIndigo();
            Console.WriteLine("method2: " + s);

            Console.WriteLine("Press <ENTER> to terminate Client.");
            Console.ReadLine();
        }
    }
}
