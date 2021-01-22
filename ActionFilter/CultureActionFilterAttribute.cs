using i18n_Demo.Helper;
using System.Globalization;
using System.Web.Mvc;

namespace i18n_Demo.ActionFilter {
    public class CultureActionFilterAttribute : ActionFilterAttribute {
        private string Language;
        public override void OnActionExecuted(ActionExecutedContext filterContext) {

            string sessonCulture = SessionHelper.Current.Culture;
            if (sessonCulture != null) {
                Language = sessonCulture;
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