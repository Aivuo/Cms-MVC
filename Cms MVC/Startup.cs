using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cms_MVC.Startup))]
namespace Cms_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
