using i18n_Demo.Helper;
using System.Globalization;
using System.Web.Mvc;

namespace i18n_Demo.ActionFilter {
    public class CultureActionFilterAttribute : ActionFilterAttribute {
        private string Language;

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            var routeLang = filterContext.RouteData.Values["lang"].ToString();
            var routeController = filterContext.RouteData.Values["controller"].ToString();
            string culture = filterContext.HttpContext.Request.Cookies["_culture"]?.Value;

            if (routeLang.Equals("Default") && culture != null) {
                filterContext.Result = new RedirectResult($"/{culture}/{routeController}");
            }

        }
        public override void OnActionExecuted(ActionExecutedContext filterContext) {

            string culture = filterContext.HttpContext.Request.Cookies["_culture"]?.Value;
            if (culture != null) {
                Language = culture;
            }
            else {
                var routeLang = filterContext.RouteData.Values["lang"].ToString();
                Language = CultureHelper.GetImplementedCulture(routeLang);
            }

            var ci = new CultureInfo(Language);
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        }
    }
}