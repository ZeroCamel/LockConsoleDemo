using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MalshalByRelObjectDemo
{
    [Serializable]
    public class Test : MarshalByRefObject
    {
        public void TestMethod(string srcAppDomain)
        {
            Console.WriteLine("Code from the '{0}' AppDomain\n called into the '{1}'.AppDomain.", srcAppDomain, Thread.GetDomain().FriendlyName);
        }
    }
}
