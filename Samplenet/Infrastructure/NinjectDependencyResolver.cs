using Ninject;
using RestaurantReservation.BL.Concrete;
using RestaurantReservation.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RestaurantReservation.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam) { kernel = kernelParam; AddBindings(); }

        public object GetService(Type serviceType) { return kernel.TryGet(serviceType); }

        public IEnumerable<object> GetServices(Type serviceType) { return kernel.GetAll(serviceType); }

        private void AddBindings()
        {
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();

            kernel.Bind<IDishRepository>().To<DishRepository>();

            kernel.Bind<IDishImageRepository>().To<DishImageRepository>();

            kernel.Bind<IDishImageMappingRepository>().To<DishImageMappingRepository>();

            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IOrderLineRepository>().To<OrderLineRepository>();
            kernel.Bind<IServeListRepository>().To<ServeListRepository>();

        }

    }
}