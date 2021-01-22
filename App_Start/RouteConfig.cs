using System.Web.Mvc;
using System.Web.Routing;

namespace i18n_Demo {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { lang = "Default", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
