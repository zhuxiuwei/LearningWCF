using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;
using Client.SecureService;

namespace Client
{
    class Program
    {
        private static void callService()
        {
            EndpointAddress ep = new EndpointAddress("http://WIN-C088QGABQ4R:8000/HelloIndigoService");
            //方法1: normal way - 用client工程里定义好的service proxy
            IHelloIndigoService proxy = ChannelFactory<IHelloIndigoService>.CreateChannel(new BasicHttpBinding(), ep);
            string s = proxy.HelloIndigo();
            Console.WriteLine("method1: " + s);
            //方法2: （2015-09-21新加） 直接调用Service端接口中定义的ServiceContract。注意这样的话需要提前在client project里引入HelloIndigo project。
            HelloIndigo.IHelloIndigoService proxy2 = ChannelFactory<HelloIndigo.IHelloIndigoService>.CreateChannel(new BasicHttpBinding(), ep); //注意调的是接口
            s = proxy2.HelloIndigo();
            Console.WriteLine("method2: " + s);
        }

        private static void callService2()
        {
            ////测试调用Serice2的方法    (2015-09-23新加)
            EndpointAddress ep2 = new EndpointAddress("http://localhost:8000/TestService2");
            HelloIndigo.IService2 proxyForService2 = ChannelFactory<HelloIndigo.IService2>.CreateChannel(new BasicHttpBinding(), ep2);
            string s = proxyForService2.Hello("my param!");
            Console.WriteLine("Service2: " + s);
            s = proxyForService2.Hello2("param2");
            Console.WriteLine("Service2: " + s);
        }

        //没用。配置文件读不上。用callSSLService2()
        private static void callSSLService()
        {
            //测试调用SSL Service (2016-02-05新加)
            EndpointAddress ep3 = new EndpointAddress("http://localhost:8000/SSLService");
            ISecureService proxyForSslService = ChannelFactory<ISecureService>.CreateChannel(new WSHttpBinding(), ep3);
            string s3 = proxyForSslService.HelloSecure("client param!");
            Console.WriteLine("SSLService: " + s3);
        }

        //把client安全相关的信息都写到code里 160215
        static void callSSLService2()
        {
            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.TransportWithMessageCredential;
            //myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;     //不能用这个！！！ 160217
            myBinding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;            //要用这个！！！ 160217

            //var myBinding = new WSHttpBinding(SecurityMode.TransportWithMessageCredential);
            //myBinding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
            //myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

            // Create the endpoint address. Note that the machine name 
            // must match the subject or DNS field of the X.509 certificate
            // used to authenticate the service. 
            //EndpointAddress ea = new EndpointAddress(new Uri("https://WIN-C088QGABQ4R:8123/SSLService"), EndpointIdentity.CreateDnsIdentity("localhost"));
            EndpointAddress ea = new EndpointAddress(new Uri("https://WIN-C088QGABQ4R:8123/SSLService"));

            // Create the client. The code for the calculator 
            // client is not shown here. See the sample applications
            // for examples of the calculator code.
            var cc = new SslClient(myBinding, ea);
            //var cc = new SecureServiceClient(myBinding, ea);  //这个也能工作，这个是通过http，add service reference生成的。 160217

            // The client must specify a certificate trusted by the server.
            cc.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindBySubjectName,
                //"localhost");   //client也是local时 170216
                "cnxiuzhu");  //client是我的笔记本时 170216
            cc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerTrust;
            cc.ClientCredentials.ServiceCertificate.Authentication.TrustedStoreLocation = StoreLocation.LocalMachine;


            // Begin using the client.
            Console.WriteLine(cc.HelloSecure("hello from SSL"));

            cc.Close();
        }

        static void Main(string[] args)
        {
            //callService();
            //callService2();
            callSSLService2();

            Console.WriteLine("Press <ENTER> to terminate Client.");
            Console.ReadLine();
        }
    }
}
