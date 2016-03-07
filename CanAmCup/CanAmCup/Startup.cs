using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CanAmCup.Startup))]
namespace CanAmCup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
