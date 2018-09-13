using MusicStore.BLL.Infrastucture;
using MusicStore.Web.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MusicStore.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var connectionSting = ConfigurationManager.ConnectionStrings["MusicStoreConnection"].ConnectionString;
            NinjectModule order = new ServiceModule(connectionSting);
            NinjectModule music = new BllServices();

            var kernel = new StandardKernel(order, music);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
