using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.Repository
{
    /// <summary>
    /// 返回码
    /// </summary>
    public static class SpResult
    {
        /// <summary>
        /// 失败
        /// </summary>
        public const int Failed = 0;

        /// <summary>
        /// 成功
        /// </summary>
        public const int Successful = 1;

        /// <summary>
        /// 登录成功
        /// </summary>
        public const int EmailSignin_Successful = 3;

        /// <summary>
        /// 邮箱还没有被激活
        /// </summary>
        public const int EmailSignin_EmailNotActive = 4;

        /// <summary>
        /// 用户名或密码不正确
        /// </summary>
        public const int EmailSignin_Failed = 5;
    }
}
