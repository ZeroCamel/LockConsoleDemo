using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LockMutexDemo
{
    class Program
    {
        //Mutex作用和Lock类似，但是它能跨进程锁资源（走的是windows内核构造）
        //Mutex互斥量

        static bool createNew = false;
        //1、调用的线程是否应拥有互斥体的初始所属权。即createNew true  时，mutex默认获得处理信号
        public static Mutex mutex = new Mutex(true, "mushroom.mutex", out createNew);
        static void Main(string[] args)
        {
            if (createNew) //第一个创建成功，已经拿到锁。无需waitOne了
            {
                try
                {
                    Run();
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            //waitone 函数作用是阻止当前线程，直到拿到其他实例释放的处理信号
            else if (mutex.WaitOne(10000,false))
            {
                try
                {
                    Run();
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            else //没有发现处理信号
            {
                Console.WriteLine("已经有实例了。");
                Console.ReadLine();
            }
        }

        static void Run()
        {
            Console.WriteLine("实例1");
            Console.ReadLine();
        }
    }
}
