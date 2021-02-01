using i18n_Demo.Helper;
using System.Globalization;
using System.Web.Mvc;

namespace i18n_Demo.ActionFilter {
    public class CultureActionFilterAttribute : ActionFilterAttribute {
        private string Language;

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            var routeLang = filterContext.RouteData.Values["lang"]?.ToString();
            var routeController = filterContext.RouteData.Values["controller"].ToString();
            var routeAction = filterContext.RouteData.Values["action"].ToString();
            string cookieCulture = filterContext.HttpContext.Request.Cookies["_culture"]?.Value;
            string defaultCulture = CultureHelper.GetDefaultCulture();


            if (cookieCulture == null) {
                if (routeLang == null) {
                    filterContext.Result = new RedirectResult($"/{defaultCulture}/{routeController}/{routeAction}");
                    CookieHelper.SetCookie(filterContext.Controller.ControllerContext, defaultCulture);
                }
                Language = CultureHelper.GetImplementedCulture(routeLang);
            }
            else {                
                if (routeLang == null) {
                    filterContext.Result = new RedirectResult($"/{cookieCulture}/{routeController}/{routeAction}");
                }
                else {
                    if (routeLang.ToLower() != cookieCulture.ToLower()) {
                        filterContext.Result = new RedirectResult($"/{cookieCulture}/{routeController}/{routeAction}");
                    }
                }
                Language = cookieCulture;
            }

            var ci = new CultureInfo(Language);
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            CookieHelper.SetCookie(filterContext.Controller.ControllerContext, Language);

        }
        public override void OnActionExecuted(ActionExecutedContext filterContext) {

            //string culture = filterContext.HttpContext.Request.Cookies["_culture"]?.Value;
            //if (culture != null) {
            //    Language = culture;
            //}
            //else {
            //    var routeLang = filterContext.RouteData.Values["lang"].ToString();
            //    Language = CultureHelper.GetImplementedCulture(routeLang);
            //}

            //var ci = new CultureInfo(Language);
            //System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            //System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        }
    }
}