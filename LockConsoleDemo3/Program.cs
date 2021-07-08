using System;
using System.Threading;

namespace LockConsoleDemo3
{
    /// <summary>
    /// 同步模型：
    ///     优惠券的获取 每一个人都有一张优惠券 每个人都有自己的知识点以及等级进度
    /// 异步模型：
    ///     Async Await 报错
    /// </summary>
    class Program
    {
        /// <summary>
        /// 对象锁
        /// </summary>
        private static readonly Object LockObj = new object();
        static void Main(string[] args)
        {

            DateTime dateTime = DateTime.Today.AddMonths(6);
            Console.WriteLine(dateTime);
            Console.Read();
            ////实例化三个人
            //Person p1 = new Person { Id = 24, Name = "Kobe" };
            //Person p2 = new Person { Id = 25, Name = "Rose" };
            //Person p3 = new Person { Id = 23, Name = "Lebl" };
            //Person p4 = new Person { Id = 27, Name = "a" };
            //Person p5 = new Person { Id = 28, Name = "b" };
            //Person p6 = new Person { Id = 29, Name = "c" };

            ////开启多线程、模拟三个人同时发起多次领取请求
            //for (int i = 0; i < 100; i++)
            //{
            //    new Thread(() =>
            //    {
            //        MutexGetCoupon(p1);
            //    }).Start();
            //    new Thread(() =>
            //    {
            //        MutexGetCoupon(p2);
            //    }).Start();
            //    new Thread(() =>
            //    {
            //        MutexGetCoupon(p3);
            //    }).Start();
            //    new Thread(() =>
            //    {
            //        MutexGetCoupon(p4);
            //    }).Start();
            //    new Thread(() =>
            //    {
            //        MutexGetCoupon(p5);
            //    }).Start();
            //    new Thread(() =>
            //    {
            //        MutexGetCoupon(p6);
            //    }).Start();
            //}
            //Console.ReadLine();
        }

        static void GetCoupon(Person person)
        {
            Console.WriteLine("date:{0:yyyy-MM-dd HH:mm:ss},name:{1},前来领取优惠券", DateTime.Now, person.Name);
            if (person.IsGetCoupon)
            {
                //假装业务处理
                Thread.Sleep(1000);
                Console.WriteLine("date:{0:yyyy-MM-dd HH:mm:ss},name:{1},已经领取，不可重复领取", DateTime.Now, person.Name);
            }
            else
            {
                //假装业务处理
                Thread.Sleep(1000);
                //领取
                person.IsGetCoupon = true;
                Console.WriteLine("date:{0:yyyy-MM-dd HH:mm:ss},name:{1},领取成功", DateTime.Now, person.Name);
            }
        }


        static void LockGetCoupon(Person person)
        {
            Console.WriteLine("date:{0:yyyy-MM-dd HH:mm:ss},name:{1},前来领取优惠券", DateTime.Now, person.Name); 
            lock (LockObj)
            {

                if (person.IsGetCoupon)
                {
                    //假装业务处理
                    Thread.Sleep(1000);
                    Console.WriteLine("date:{0:yyyy-MM-dd HH:mm:ss},name:{1},已经领取，不可重复领取", DateTime.Now, person.Name);
                }
                else
                {
                    //假装业务处理
                    Thread.Sleep(1000);
                    //领取
                    person.IsGetCoupon = true;
                    Console.WriteLine("date:{0:yyyy-MM-dd HH:mm:ss},name:{1},领取成功", DateTime.Now, person.Name);
                } 
            }
        }

        /// <summary>
        /// 创建和释放锁的开销增大 内核锁 多进程间共享
        /// </summary>
        /// <param name="person"></param>
        static void MutexGetCoupon(Person person)
        {
            Console.WriteLine("date:{0:yyyy-MM-dd HH:mm:ss},name:{1},前来领取优惠券", DateTime.Now, person.Name);

            using (var mutex = new Mutex(false,person.Id.ToString()))
            {
                try
                {
                    if (mutex.WaitOne(-1,false))
                    {

                        if (person.IsGetCoupon)
                        {
                            //假装业务处理
                            Thread.Sleep(1000);
                            Console.WriteLine("date:{0:yyyy-MM-dd HH:mm:ss},name:{1},已经领取，不可重复领取", DateTime.Now, person.Name);
                        }
                        else
                        {
                            //假装业务处理
                            Thread.Sleep(1000);
                            //领取
                            person.IsGetCoupon = true;
                            Console.WriteLine("date:{0:yyyy-MM-dd HH:mm:ss},name:{1},领取成功", DateTime.Now, person.Name);
                        }

                        person.count += 1;
                        Console.WriteLine("count:{0}", person.count);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    mutex.ReleaseMutex();
                    Console.WriteLine(person.Name.ToString()+"释放锁"+mutex.GetHashCode());
                }
            }
        }
    }
}
