using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestaurantReservation.WebUI.Startup))]
namespace RestaurantReservation.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
