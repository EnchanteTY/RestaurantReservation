using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Samplenet.Startup))]
namespace Samplenet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
