using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LockConsoleDemo2
{
    class Program
    {
        //银行取钱案例，进程内锁
        static void Main(string[] args)
        {
            Thread[] thread = new Thread[10];
            Account acc = new Account(1000);

            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                thread[i] = t;
            }
            for (int i = 0; i < 10; i++)
            {
                thread[i].Start();
            }
            Console.ReadKey();
        }
    }
}
