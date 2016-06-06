using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Youshare.Startup))]
namespace Youshare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
