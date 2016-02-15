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

        static void hostFromStrach(){
            //方法1： from strach。注意用方法1的时候，App.config里方法2的设置都要删除，否则会报错:"This collection already contains an address with scheme http.  There can be at most one address per scheme in this collection. ..."
            using (ServiceHost host = new ServiceHost(typeof(HelloIndigoService), new Uri("http://localhost:8000/HelloIndigoService")))   //注意： typeof里，必须是class，不能是interface
            {
                host.AddServiceEndpoint(typeof(IHelloIndigoService), new BasicHttpBinding(), "");   //注意，这里的typeof又是接口了。真是够乱七八糟的。
                host.Open();    // Service channel craeted

                //Service 2 test 2015-09-23新加
                using (ServiceHost host2 = new ServiceHost(typeof(Service2), new Uri("http://localhost:8000/TestService2")))    //注意：启动多个ServiceHost时，不同的ServiceHost，URI必须不同。
                {
                    host2.AddServiceEndpoint(typeof(IService2), new BasicHttpBinding(), "");
                    host2.Open();    // Service channel craeted

                    Console.WriteLine("Press <ENTER> to terminate the service host");   //一定要在using内。否则跳出using，serviehost就被资源关闭了
                    Console.ReadLine();
                }
            }   
        }

        static void hostWithAppConfig()
        {
            //方法2： with App.config
            using (ServiceHost host = new ServiceHost(typeof(HelloIndigoService)))
            {
                host.Open();    // Service channel craeted

                //Service 2 test 2015-09-23新加
                using (ServiceHost host2 = new ServiceHost(typeof(Service2), new Uri("http://localhost:8000/TestService2")))    //注意：启动多个ServiceHost时，不同的ServiceHost，URI必须不同。
                {
                    host2.AddServiceEndpoint(typeof(IService2), new BasicHttpBinding(), "");
                    host2.Open();    // Service channel craeted

                    Console.WriteLine("Press <ENTER> to terminate the service host");
                    Console.ReadLine();
                }
            } 
        }

        static void hostSSL()
        {
            //using (ServiceHost host2 = new ServiceHost(typeof(SecureService), new Uri("http://localhost:8000/SecureService"))) 
            //{
            //    host2.AddServiceEndpoint(typeof(ISecureService), new BasicHttpBinding(), "");
            //    host2.Open();    // Service channel craeted

            //    Console.WriteLine("Press <ENTER> to terminate the service host");   //一定要在using内。否则跳出using，serviehost就被资源关闭了
            //    Console.ReadLine();
            //}


            using (ServiceHost host3 = new ServiceHost(typeof(SecureService)))
            {
                host3.Open();
                Console.WriteLine("Press <ENTER> to terminate the service host");   //一定要在using内。否则跳出using，serviehost就被资源关闭了
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            //Basic HTTP WCF host
            //hostFromStrach();
            //hostWithAppConfig();
            
            //ssl WCF host
            hostSSL();
        }
    }
}
