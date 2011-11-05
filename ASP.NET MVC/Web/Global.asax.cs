using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Spring.Web.Mvc;
using Spring.Context.Support;

namespace Web {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : SpringMvcApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            //Enable route to elmah error log
            routes.IgnoreRoute("admin/elmah.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start() {            
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        /// <summary>
        /// Builds the dependency resolver for spring application with
        /// Spring CodeConfig.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Web.Mvc.IDependencyResolver"/> instance.
        /// </returns>        
        protected override IDependencyResolver BuildDependencyResolver() {
            CodeConfigApplicationContext ctx = new CodeConfigApplicationContext();
            ctx.ScanAllAssemblies();
            ctx.Refresh();

            return new SpringMvcDependencyResolver(ctx);
        }
    }
}