using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using HelloIndigo;
using System.ServiceModel.Description;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            //Basic HTTP WCF host. Enable this when test basic HTTP errvice, or HTTP/HTTPS Routing service.
            //hostFromStrach();
            //hostWithAppConfig();

            //ssl WCF host
            hostSSL();
        }

        //HTTP的。
        static void hostFromStrach(){
            //方法1： from strach。注意用方法1的时候，App.config里方法2的设置都要删除，否则会报错:"This collection already contains an address with scheme http.  There can be at most one address per scheme in this collection. ..."
            using (ServiceHost host = new ServiceHost(typeof(HelloIndigoService), new Uri("http://localhost:8000/HelloIndigoService")))   //注意： typeof里，必须是class，不能是interface
            {
                //enable HTTP get
                ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (smb == null)  smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;  
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                //Enable IncludeExceptionDetailInFaults
                ServiceDebugBehavior debug = host.Description.Behaviors.Find<ServiceDebugBehavior>();
                if (debug == null) debug = new ServiceDebugBehavior();
                debug.IncludeExceptionDetailInFaults = true;    
                host.Description.Behaviors.Remove( typeof(ServiceDebugBehavior));   //必须先remove，否则报错：Unhandled Exception: System.ArgumentException: The value could not be added to the collection, as the collection already contains an item of the same type: 'System.ServiceModel.Description.ServiceDebugBehavior'. This collection only supports one instance of each type.
                host.Description.Behaviors.Add(debug);  

                host.AddServiceEndpoint(typeof(IHelloIndigoService), new BasicHttpBinding(), "");   //注意，这里的typeof又是接口了。真是够乱七八糟的。
                host.Open();    // Service channel craeted

                //Service 2 test 2015-09-23新加
                using (ServiceHost host2 = new ServiceHost(typeof(Service2), new Uri("http://localhost:8000/TestService2")))    //注意：启动多个ServiceHost时，不同的ServiceHost，URI必须不同。
                {
                    //enable HTTP get
                    ServiceMetadataBehavior smb2 = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                    host2.Description.Behaviors.Add(smb);
                    host2.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
                    host2.Description.Behaviors.Add(debug); 

                    host2.AddServiceEndpoint(typeof(IService2), new BasicHttpBinding(), "");
                    host2.Open();    // Service channel craeted

                    Console.WriteLine("Press <ENTER> to terminate the service host");   //一定要在using内。否则跳出using，serviehost就被资源关闭了
                    Console.ReadLine();
                }
            }   
        }

        //HTTP的。
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

        //用来测试SSL的server - client和SSL的serve通信。和routing service没关系。
        //如果要测试routing service，应该调用hostFromStrach()。再让Routing service route到hostFromStrach的服务上。
        static void hostSSL()
        {
            using (ServiceHost host3 = new ServiceHost(typeof(SecureService)))
            {
                host3.Open();
                Console.WriteLine("Press <ENTER> to terminate the service host");   //一定要在using内。否则跳出using，serviehost就被资源关闭了
                Console.ReadLine();
            }
        }

    }
}
