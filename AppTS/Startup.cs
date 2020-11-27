using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppTS.Startup))]
namespace AppTS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
