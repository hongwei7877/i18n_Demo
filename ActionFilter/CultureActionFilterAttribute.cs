using i18n_Demo.Extensions;
using i18n_Demo.Helper;
using System.Globalization;
using System.Web.Mvc;
using static i18n_Demo.Helper.CultureHelper;

namespace i18n_Demo.ActionFilter {
    public class CultureActionFilterAttribute : ActionFilterAttribute {
        private string Language;
        public override void OnActionExecuted(ActionExecutedContext filterContext) {

            string sessonCulture = SessionHelper.Current.Culture;
            if(sessonCulture != null) {
                Language = sessonCulture;
            }
            else {
                if (filterContext.RouteData.Values.ContainsKey("lang")) {
                    var routeLang = filterContext.RouteData.Values["lang"].ToString();
                    Language = CultureHelper.GetImplementedCulture(routeLang);
                }
            }
         
            var ci = new CultureInfo(Language);
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        }
    }
}