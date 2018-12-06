using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PX.Startup))]
namespace PX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
