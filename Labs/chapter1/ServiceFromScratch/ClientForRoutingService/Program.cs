using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using ClientForRoutingService.HelloIndigoService;

namespace ClientForRoutingService
{
    //160219添加
    class Program
    {
        static void Main(string[] args)
        {
            CallHttpRoutingService();   //HTTP test
            CallHttpsRoutingService();  //HTTPS test
        }

        //HTTP的。从配置文件里读。
        static void CallHttpRoutingService()
        {
            Service2Client serv2Client = new Service2Client();
            HelloIndigoServiceClient helloClient = new HelloIndigoServiceClient();
            Console.WriteLine("--- test HTTP HelloIndigoService ---");
            Console.WriteLine(helloClient.HelloIndigo());
            Console.WriteLine("--- test HTTP Service2 ---");
            Console.WriteLine(serv2Client.Hello("parm for hello"));
            Console.WriteLine(serv2Client.Hello2("parm for hello2"));
            Console.WriteLine(serv2Client.Hello2("BAD"));
            serv2Client.Close();
            helloClient.Close();
        }

        //HTTPS的。配置都在code里。
        static void CallHttpsRoutingService()
        {
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.TransportWithMessageCredential;
            myBinding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
            myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            myBinding.Security.Message.EstablishSecurityContext = false;

            EndpointAddress helloEA = new EndpointAddress(new Uri("https://WIN-C088QGABQ4R:8123/RoutingSecureService/HelloIndigoRouter"));
            var helloClient = new HelloIndigoServiceClient(myBinding, helloEA);
            helloClient.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "cnxiuzhu");
            helloClient.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerTrust;
            helloClient.ClientCredentials.ServiceCertificate.Authentication.TrustedStoreLocation = StoreLocation.LocalMachine;

            EndpointAddress service2EA = new EndpointAddress(new Uri("https://WIN-C088QGABQ4R:8123/RoutingSecureService/Service2Router"));
            var serv2Client = new Service2Client(myBinding, service2EA);
            serv2Client.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "cnxiuzhu");
            serv2Client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerTrust;
            serv2Client.ClientCredentials.ServiceCertificate.Authentication.TrustedStoreLocation = StoreLocation.LocalMachine;

            System.Net.ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

            Console.WriteLine("\r\n=== test HTTPS HelloIndigoService ===");
            Console.WriteLine(helloClient.HelloIndigo());
            Console.WriteLine("=== test HTTPS Service2 ===");
            Console.WriteLine(serv2Client.Hello("parm for hello SSL"));
            Console.WriteLine(serv2Client.Hello2("parm for hello2 SSL"));

            serv2Client.Close();
            helloClient.Close();
        }
    }
}
