using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Client
{
    [ServiceContract]
    public interface ISecureService 
    {
        [OperationContract]
        //以下两种写法都行，注意参数名"stringSecure"一定要对！！ 160218
        //string HelloSecure([MessageParameter(Name = "stringSecure")]string s); 
        string HelloSecure(string stringSecure); 

    }

    //因为add service reference总不work，自己模仿着写了下面的类、构造函数和方法。 160215
    public class SslClient : System.ServiceModel.ClientBase<Client.ISecureService>, Client.ISecureService
    {
        public SslClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }

        public string HelloSecure([MessageParameter(Name = "stringSecure")]string s)
        {
            return base.Channel.HelloSecure(s);
        }
    }
}
