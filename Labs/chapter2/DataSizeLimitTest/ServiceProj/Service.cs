using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

/*
zhuxw 10/2/2015
 */
namespace MyService
{
     [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<MyResult> GetResult(int count);
    }

     public class ServiceImpl : IService  //注意：class类不需要再声明ServiceContract、OperationContract
    {
         public List<MyResult> GetResult(int count)
        {
            var res = new List<MyResult>();
            for (int i = 1; i <= count; i++)
            {
                MyResult re = new MyResult();
                re.ID = i;
                res.Add(re);
            }
            Console.WriteLine(res.Count);
            return res;
        }
    }
}
