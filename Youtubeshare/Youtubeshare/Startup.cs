using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Youtubeshare.Startup))]
namespace Youtubeshare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
