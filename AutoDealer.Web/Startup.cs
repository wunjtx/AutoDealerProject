using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoDealer.Web.Startup))]
namespace AutoDealer.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
