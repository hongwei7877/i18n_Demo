using i18n_Demo.Helper;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;
namespace i18n_Demo {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            string langConstraint = string.Join("|",CultureHelper.GetAllImplementedCultures().Select(x => x.Value));
            routes.MapRoute(
                name: "Culture",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { lang =  $"({langConstraint})"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
