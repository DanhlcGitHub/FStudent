using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FAdmin.Startup))]
namespace FAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
