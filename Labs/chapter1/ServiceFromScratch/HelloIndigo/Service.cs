using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

/*
zhuxw 5/18/2015
 */
namespace HelloIndigo
{
    //Step 1: Define service contract.
    //[ServiceContract(Name = "HelloIndigoService", Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
     [ServiceContract]
    public interface IHelloIndigoService
    {
        [OperationContract]
        string HelloIndigo();
    }

   // [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
     public class HelloIndigoService : IHelloIndigoService  //注意：class类不需要再声明ServiceContract、OperationContract
    {
        public string HelloIndigo()
        {
            return "Hello Indigo!";
        }
    }


    //测验一个project启动两个service。
    [ServiceContract]
     public interface IService2
     {
         [OperationContract]
        string Hello(string s);

         [OperationContract]
         string Hello2([MessageParameter(Name="string")]string s);  //Learn WCF p89。书上说只能这么写，像Hello()那么写不行，但实验证明是可以的。不明白。
     }

     public class Service2 : IService2
     {
         public string Hello(string s)
         {
             return String.Format("Service2 Hello Method! Your parameter is: {0}", s);
         }

         public string Hello2([MessageParameter(Name = "string")]string s)
         {
             return String.Format("Service2 Hello2 Method! Your parameter is: {0}", s);
         }
     }

     //测试SSL Service. 1602015 http://www.codeproject.com/Articles/36683/simple-steps-to-enable-X-certificates-on-WCF?fid=1541161&fr=1#xx0xx
     [ServiceContract]
     public interface ISecureService
     {
         [OperationContract]
         string HelloSecure([MessageParameter(Name = "stringSecure")]string s); 
     }
     public class SecureService : ISecureService
     {
         public string HelloSecure([MessageParameter(Name = "stringSecure")]string s)
         {
             return String.Format("SecureService HelloSecure Method! Your parameter is: {0}", s);
         }
     }
}
