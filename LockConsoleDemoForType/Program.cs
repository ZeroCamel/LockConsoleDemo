using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LockConsoleDemoForType
{
    class Program
    {
        static void Main(string[] args)
        {
            //=>lamada表达式 goes to 匿名函数 =>前面的是参数，后面的是函数体
            new Thread(new ThreadStart(() =>
            {
                lock (typeof(int))
                {
                    Thread.Sleep(3000);
                    Console.WriteLine("Thread1释放");
                }
            })).Start();
            Thread.Sleep(1000);
            lock(typeof(int))
            {
                Console.WriteLine("Thread2释放");
            }
            Console.ReadKey();
        }
    }
}
