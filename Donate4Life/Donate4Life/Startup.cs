using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Donate4Life.Startup))]
namespace Donate4Life
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
