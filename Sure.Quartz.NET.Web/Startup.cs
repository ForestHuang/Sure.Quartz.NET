using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sure.Quartz.NET.Web.Startup))]
namespace Sure.Quartz.NET.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
