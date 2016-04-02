using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using HelloIndigo;

namespace HostSSLBasicHttp
{
    class Program
    {
        static void Main(string[] args)
        {
            //host SSL service With basicHttpBinding
            Program.hostSSLWithBasicHttp();
        }

        public static void hostSSLWithBasicHttp()
        {
            using (ServiceHost host = new ServiceHost(typeof(SecureServiceBasicHttp)))
            {
                host.Open();
                Console.WriteLine("Press <ENTER> to terminate the service host");   //一定要在using内。否则跳出using，serviehost就被资源关闭了
                Console.ReadLine();
            }
        }

    }

    //测试SSL Service - BaiscHTTPBinding. 160401
    [ServiceContract]
    public interface ISecureServiceBasicHttp
    {
        [OperationContract]
        string HelloSecure([MessageParameter(Name = "stringSecure")]string s);
    }
    public class SecureServiceBasicHttp : ISecureServiceBasicHttp
    {
        public string HelloSecure([MessageParameter(Name = "stringSecure")]string s)
        {
            Console.WriteLine("Request Incoming SecureServiceBasicHttp! Parameter: " + s);
            return String.Format("SecureService BasicHttpBing HelloSecure() Method! Your parameter is: {0}", s);
        }
    }
}
