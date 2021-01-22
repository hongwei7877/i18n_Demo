using i18n_Demo.ActionFilter;
using i18n_Demo.Extensions;
using i18n_Demo.Helper;
using i18n_Demo.Models;
using System.Web.Mvc;

namespace i18n_Demo.Controllers {
    [CultureActionFilter]
    public class HomeController : Controller {
        public ActionResult Index() {

            string sessonCulture = SessionHelper.Current.Culture;
            if (sessonCulture != null) {
                ViewBag.CookieCulture = sessonCulture;
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
                SessionHelper.Current.Culture = culture;
            }
            ViewBag.CookieCulture = SessionHelper.Current.Culture;

            #endregion
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}