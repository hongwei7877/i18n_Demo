using i18n_Demo.ActionFilter;
using i18n_Demo.Extensions;
using i18n_Demo.Helper;
using i18n_Demo.Models;
using MultiLangResx.Resources;
using System.Web.Mvc;

namespace i18n_Demo.Controllers {
    [CultureActionFilter]
    public class HomeController : Controller {
        public ActionResult Index() {

            string cookieCulture = Request.Cookies["_culture"]?.Value;
            if (cookieCulture != null) {

                var ln = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
                ViewBag.CookieCulture = cookieCulture + $"  CI :{ln}";
            }
            else {
                ViewBag.CookieCulture = "(None)";
            }

            ViewData["LangSelectList"] = CultureHelper.GetAllImplementedCultures()
                .ToSelectList(x => x.Value,
                              x => x.Value,
                              isOrder: true);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TextViewModel vm) {

            ViewData["LangSelectList"] = CultureHelper.GetAllImplementedCultures()
                .ToSelectList(x => x.Value,
                              x => x.Value,
                              true);

            #region 更改語系
            var culture = CultureHelper.GetImplementedCulture(vm.Name);

            if (culture != null) {
                CookieHelper.SetCookie(this.ControllerContext, culture);
            }
            ViewBag.CookieCulture = Request.Cookies["_culture"].Value;

            #endregion
            return Redirect($"/{culture}");
        }

        public ActionResult About() {
            ViewBag.Message = Resource.AboutDetail;
            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = Resource.ContactDetail;
            return View();
        }
    }
}