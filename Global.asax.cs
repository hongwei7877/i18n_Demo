using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace i18n_Demo {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_BeginRequest(object sender, EventArgs e) {
            //HttpCookie cultureCookie = Request.Cookies["_culture"];
            //CultureInfo ci = default;
            //try {              
            //    if (cultureCookie != null) {
            //        ci = new CultureInfo(cultureCookie.Value);
            //    }
            //    else {
            //        //取得用戶端語言喜好設定(已排序的字串陣列)
            //        var userLanguages = Request.UserLanguages;
            //        if (userLanguages.Length > 0) {
            //            try {
            //                ci = new CultureInfo(userLanguages[0]);
            //            }
            //            catch (CultureNotFoundException) {
            //                ci = CultureInfo.InvariantCulture;
            //            }
            //        }
            //        else {
            //            ci = CultureInfo.InvariantCulture;
            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //finally
            //{
            //    System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            //    System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            //}
        }
    }
}
