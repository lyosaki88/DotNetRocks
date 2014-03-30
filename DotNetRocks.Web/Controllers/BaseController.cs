using DotNetRocks.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using DotNetRocks.Web.Configurations;
using System.Configuration;
using System.Threading.Tasks;

namespace DotNetRocks.Web.Controllers
{
    /// <summary>
    /// 项目中所有Controller的基类，包含了控制器中经常使用的 DbContext实例, UserManager实例，Dispose方法等
    /// </summary>
    public class BaseController : Controller
    {
        public BaseController()
            : base()
        {
        }
        private ApplicationDbContext _dbContext;
        protected ApplicationDbContext DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = ApplicationDbContext.Create();
                }
                return _dbContext;
            }
        }

        private ApplicationUserManager _userManager;
        protected ApplicationUserManager UserManager
        {
            get
            {
                if (_userManager == null)
                {
                    _userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                }
                return _userManager;
            }
        }
        private IAuthenticationManager _authenticationManager;
        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                if (_authenticationManager == null)
                {
                    _authenticationManager = HttpContext.GetOwinContext().Authentication;
                }
                return _authenticationManager;
            }
        }
        private WebSiteConfig _webSiteConfig;
        protected WebSiteConfig WebSiteConfig
        {
            get
            {
                if (_webSiteConfig == null)
                {
                    _webSiteConfig = (WebSiteConfig)ConfigurationManager.GetSection("application/website");
                }
                return _webSiteConfig;
            }
        }

        /// <summary>
        /// 当前登录用户的ID
        /// </summary>
        protected virtual string _currentUserId
        {
            get
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    return this.User.Identity.GetUserId();
                }
                return null;
            }
        }

        /// <summary>
        /// 当前登录用户的用户名
        /// </summary>
        protected virtual string _currentUserName
        {
            get
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    return this.User.Identity.GetUserName();
                }
                return null;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.WebSiteName = WebSiteConfig.Name;
            ViewBag.BuildVersion = WebSiteConfig.Version;

            base.OnActionExecuting(filterContext);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }
    }
}