using DotNetRocks.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetRocks.Web.Controllers
{
    /// <summary>
    /// 项目中所有Controller的基类，包含了控制器中经常使用的 DbContext实例, UserManager实例，Dispose方法等
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 当前上下文中的AppDbContext实例
        /// </summary>
        protected AppDbContext _dbContext { get; private set; }
        /// <summary>
        /// 当前上下文中的UserManager实例
        /// </summary>
        protected UserManager<ApplicationUser> _userManager { get; private set; }

        public BaseController()
        {
            _dbContext = new AppDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new AppDbContext()));
        }
        /// <summary>
        /// 当前登录用户的ID
        /// </summary>
        public virtual string CurrentUserId
        {
            get
            {
                if (!this.User.Identity.IsAuthenticated)
                    throw new ApplicationException("当前未有合法登陆的用户");
                return this.User.Identity.GetUserId();
            }
        }

        /// <summary>
        /// 当前登录用户的用户名
        /// </summary>
        public virtual string CurrentUserName
        {
            get
            {
                if (!this.User.Identity.IsAuthenticated)
                    throw new ApplicationException("当前未有合法登陆的用户");
                return this.User.Identity.GetUserName();
            }
        }

        /// <summary>
        /// 当前登录用户的完整信息
        /// </summary>
        public virtual ApplicationUser CurrentUserProfile
        {
            get
            {
                if (string.IsNullOrEmpty(this.CurrentUserId))
                    throw new ApplicationException("当前未有合法登陆的用户");
                return _userManager.FindById(this.CurrentUserId);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this._dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
            if (disposing && this._userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }
            base.Dispose(disposing);
        }
	}
}