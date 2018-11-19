using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockConsoleDemo2
{
    //账户
    public class Account
    {
        private object thisLock = new object();
        int balance;

        Random r = new Random();

        //构造函数
        public Account(int initial)
        {
            balance = initial;
        }
        //取款
        public int WithDraw(int Amount)
        {
            if (balance < 0)
            {
                throw new Exception("Negative Balance!");
            }
            lock (thisLock)
            {
                if (Amount <= balance)
                {
                    Console.WriteLine("Balance before Withdraw:" + balance);
                    Console.WriteLine("Amount to Withdraw     :-" + Amount);
                    balance = balance - Amount;
                    Console.WriteLine("Balance after WithDraw:" + balance);
                    return Amount;
                }
                else
                {
                    return 0;//trasaction rejected
                }
            }
        }
        /// <summary>
        /// 模拟取钱的用户数
        /// </summary>
        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                WithDraw(r.Next(1,100));
            }
        }
    }
}
