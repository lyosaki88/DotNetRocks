using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetRocks.Web.Startup))]
namespace DotNetRocks.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
