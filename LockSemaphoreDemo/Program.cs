using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.AccessControl;
using System.Threading;

namespace LockSemaphoreDemo
{
    class Program
    {
        //升级版的Mutex,Mutex对一个资源进行锁，Samphore对多个资源进行锁

        //先将托管代码转换成本地模式代码、再转换为本地内核代码
        static void Main(string[] args)
        {
            Console.WriteLine("准备处理队列");

            bool createNew = false;

            SemaphoreSecurity ss = new SemaphoreSecurity();

            Semaphore semaphore = new Semaphore(2, 2, "mushroom.semaphore", out createNew, null);

            for (int i = 0; i < 5; i++)
            {
                new Thread((arg) =>
                    {
                        semaphore.WaitOne();
                        Console.Write(arg + "处理中");
                        Thread.Sleep(1000);
                        semaphore.Release();
                    }).Start(i);
            }
            Console.Read();
        }
    }
}
