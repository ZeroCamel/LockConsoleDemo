using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockConsoleDemoString
{
    class Program
    {
        //C# 中String 对象的特殊性
        //每次变动都是一个新对象值，如果两次对象的值一致就是同一个对象
        //字符串的生命周期是整个进程的，也是跨AppDomain
        static void Main(string[] args)
        {
            int str1 = 1;
            int str2 = 1;
            var result1 = object.ReferenceEquals(str1, str2);
            var result2 = object.ReferenceEquals(str1, 2);
            Console.WriteLine(result1 + " " + result2);

            string str3 = "1";
            string str4 = "1";
            var result3 = object.ReferenceEquals(str3, str4);
            var result4 = object.ReferenceEquals(str3, "2");
            Console.Write(result3 + " " + result4);

            Console.Read();
        }
    }
}
