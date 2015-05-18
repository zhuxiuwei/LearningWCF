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
    //[ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    //public interface IHelloIndigoService
    //{
    //    [OperationContract]
    //    string HelloIndigo();
    //}

    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public class HelloIndigoService
    {
        [OperationContract]
        public string HelloIndigo()
        {
            return "Hello Indigo!";
        }
    }
}
