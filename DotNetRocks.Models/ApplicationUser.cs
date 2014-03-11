using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetRocks.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
            : base()
        {

        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 性别, True: 男 .False: 女
        /// </summary>
        public General General { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// QQ号
        /// </summary>
        public string QQ { get; set; }

    }

    /// <summary>
    /// 性别
    /// </summary>
    public enum General
    {
        /// <summary>
        /// 男
        /// </summary>
        Male,
        /// <summary>
        /// 女
        /// </summary>
        Female
    }
}
