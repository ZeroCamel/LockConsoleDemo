using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MalshalByRelObjectDemo
{
    class Program
    {
        //跨应用程序域的两种方法
        //1、传值 by value
        //2、传引用 by rel

        //DOMAIN-NEUTRAL 领域中立
        //卸载异常-CannotUnloadAppDomainException
        static void Main(string[] args)
        {
            AppDomain domain = AppDomain.CreateDomain("MyNewDomain", null, null);

            Test test = (Test)domain.CreateInstanceAndUnwrap(Assembly.GetCallingAssembly().FullName, "Test");

            test.TestMethod(Thread.GetDomain().FriendlyName);

            AppDomain.Unload(domain);

            Console.Read();
        }
    }
}
