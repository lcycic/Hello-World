using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShuaDanPingTai.Startup))]
namespace ShuaDanPingTai
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
