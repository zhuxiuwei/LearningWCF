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
            
            EndpointAddress ep = new EndpointAddress("http://localhost:8000/HelloIndigoService");
            
            //方法1: normal way - 用client工程里定义好的service proxy
            IHelloIndigoService proxy = ChannelFactory<IHelloIndigoService>.CreateChannel(new BasicHttpBinding(), ep);
            string s = proxy.HelloIndigo();
            Console.WriteLine("method1: " + s);
            //方法2: （2015-09-21新加） 直接调用Service端接口中定义的ServiceContract。注意这样的话需要提前在client project里引入HelloIndigo project。
            HelloIndigo.IHelloIndigoService proxy2 = ChannelFactory<HelloIndigo.IHelloIndigoService>.CreateChannel(new BasicHttpBinding(), ep); //注意调的是接口
            s = proxy2.HelloIndigo();
            Console.WriteLine("method2: " + s);

            ////测试调用Serice2的方法    (2015-09-23新加)
            //EndpointAddress ep2 = new EndpointAddress("http://localhost:8000/TestService2");
            //HelloIndigo.IService2 proxyForService2 = ChannelFactory<HelloIndigo.IService2>.CreateChannel(new BasicHttpBinding(), ep2);
            //s = proxyForService2.Hello("my param!");
            //Console.WriteLine("Service2: " + s);
            //s = proxyForService2.Hello2("param2");
            //Console.WriteLine("Service2: " + s);

            //测试调用SSL Service (2016-02-05新加)
            //EndpointAddress ep3 = new EndpointAddress("http://localhost:8000/SSLService");
            //ISSLService proxyForSslService = ChannelFactory<ISSLService>.CreateChannel(new BasicHttpBinding(), ep3);
            //string s3 = proxyForSslService.HelloSSL("client param!");
            //Console.WriteLine("SSLService: " + s3);
            
            //Console.WriteLine("Press <ENTER> to terminate Client.");
            //Console.ReadLine();
        }
    }
}
