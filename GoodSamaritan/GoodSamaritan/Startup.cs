using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoodSamaritan.Startup))]
namespace GoodSamaritan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
