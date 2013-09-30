using System.Web.Mvc;
using System.Web.Routing;
using CodeFirstServices.Interfaces;
using CodeFirstServices.Services;
using CodeFirstServices.Services.Services;
using EasyCombos.DAL.DBInteractions;
using EasyCombos.DAL.EntityRepositories;
using Microsoft.Practices.Unity;
using EasyCombos.UI.IoC;

namespace EasyCombos.UI
{
   
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            IUnityContainer container = GetUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private IUnityContainer GetUnityContainer()
        {
            
            //Create UnityContainer          
            IUnityContainer container = new UnityContainer()
            .RegisterType<IDBFactory, DBFactory>(new HttpContextLifetimeManager<IDBFactory>())
            .RegisterType<IUnitOfWork, UnitOfWork>(new HttpContextLifetimeManager<IUnitOfWork>())
            .RegisterType<IFoodCategoryService, FoodCategoryService>(new HttpContextLifetimeManager<IFoodCategoryService>())
            .RegisterType<IFoodCategoryRepository, FoodCategoryRepository>(new HttpContextLifetimeManager<IFoodCategoryRepository>())
            .RegisterType<IFoodItemService, FoodItemService>(new HttpContextLifetimeManager<IFoodItemService>())
            .RegisterType<IFoodItemRepository, FoodItemRepository>(new HttpContextLifetimeManager<IFoodItemRepository>())
            .RegisterType<IOfferTypeService, OfferTypeService>(new HttpContextLifetimeManager<IOfferTypeService>())
            .RegisterType<IOfferTypeRepository, OfferTypeRepository>(new HttpContextLifetimeManager<IOfferTypeRepository>())
            .RegisterType<IOrderService, OrderService>(new HttpContextLifetimeManager<IOrderService>())
            .RegisterType<IOrderRepository, OrderRepository>(new HttpContextLifetimeManager<IOrderRepository>());
         
            return container;
        }
    }
}