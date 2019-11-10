using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Memoria.Startup))]
namespace Memoria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
