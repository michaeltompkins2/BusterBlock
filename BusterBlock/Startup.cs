using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusterBlock.Startup))]
namespace BusterBlock
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
