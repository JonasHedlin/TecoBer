using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TecoBerBP.Startup))]
namespace TecoBerBP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
