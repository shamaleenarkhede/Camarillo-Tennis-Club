using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Camarillo_Tennis_Club.Startup))]
namespace Camarillo_Tennis_Club
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
