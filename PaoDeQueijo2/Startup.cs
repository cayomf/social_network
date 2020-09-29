using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PaoDeQueijo2.Startup))]
namespace PaoDeQueijo2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
