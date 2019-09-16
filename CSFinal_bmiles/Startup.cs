using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSFinal_bmiles.Startup))]
namespace CSFinal_bmiles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
