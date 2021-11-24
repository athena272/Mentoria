using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Check2.Startup))]
namespace Check2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
