using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockConsoleDemo3
{
    /// <summary>
    /// Person类
    /// </summary>
    public class Person
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///  姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否获得优惠券
        /// </summary>
        public bool IsGetCoupon { get; set; }

        public int count { get; set; }
    }
}
