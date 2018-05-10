using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Emilia.Flowers.Startup))]
namespace Emilia.Flowers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
