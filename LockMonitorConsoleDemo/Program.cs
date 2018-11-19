using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LockMonitorConsoleDemo
{
    //锁的原语
    //Monitor是静态的 不需要实例化就可以调用
    //.NET FRAMEWORK中的每个对象有一个与之关联的锁
    //保证任何时间都只有一个线程可以访问对象实例变量和方法

    //每个对象都提供一个允许自己进入等待状态的机制

    //目的：保证线程之间通信

    //等待通知
    class Program
    {
        //全局静态变量
        private static string str = "mushroom";
        static void Main(string[] args)
        {
            new Thread(() =>
            {
                bool isGetLock = false;
                //任意两个线程不可以同时进入Enter()方法
                Monitor.Enter(str, ref isGetLock);
                try
                {
                    Console.WriteLine("Thread1第一次获取锁");
                    Thread.Sleep(5000);
                    Console.WriteLine("Thread1暂时释放锁，并等待其他线程释放通知信号！");
                    //等待释放锁
                    Monitor.Wait(str);
                    Console.WriteLine("Thread1接到通知，第二次获取锁！");
                    Thread.Sleep(1000);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (isGetLock)
                    {
                        Monitor.Enter(str);
                        Console.WriteLine("Thread1释放锁");
                    }
                }
            }).Start();

            //lamda 匿名表达式 线程实例化
            new Thread(() =>
            {
                bool isGetLock = false;
                Monitor.Enter(str, ref isGetLock);

                try
                {
                    Console.WriteLine("Thread2获得锁");
                    Thread.Sleep(5000);
                    //通知进程1
                    Monitor.Pulse(str);
                    Console.WriteLine("Thread2通知其他线程，改变状态。");
                    Thread.Sleep(1000);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (isGetLock)
                    {
                        Monitor.Exit(str);
                        Console.WriteLine("Thread2释放锁");
                    }
                }
            }).Start();
        }
    }
}
