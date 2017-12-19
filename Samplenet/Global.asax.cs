using Ninject;
using Ninject.Web.Common.WebHost;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RestaurantReservation.WebUI
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            DependencyResolver.SetResolver(new Infrastructure.NinjectDependencyResolver(kernel));
        }
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            //Database.SetInitializer(new DbInitializer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

    }
}
