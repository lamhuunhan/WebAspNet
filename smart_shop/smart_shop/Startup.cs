using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(smart_shop.Startup))]
namespace smart_shop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
