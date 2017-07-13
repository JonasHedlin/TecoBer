using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace TecoBer365
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
