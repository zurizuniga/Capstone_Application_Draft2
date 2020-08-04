using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Capstone_Application_Draft2.Startup))]
namespace Capstone_Application_Draft2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
