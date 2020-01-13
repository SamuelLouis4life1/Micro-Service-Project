using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppOnlineStore.Startup))]
namespace WebAppOnlineStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
