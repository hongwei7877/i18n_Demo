using System;
using System.Web;
using System.Web.Mvc;

namespace i18n_Demo.Helper {
    public class CookieHelper {
        private CookieHelper() {

        }

        public static void SetCookie(ControllerContext context, string culture) {

            var cultureCookie = new HttpCookie("_culture") {
                Value = culture,
                HttpOnly = true,
                Expires = DateTime.MinValue
            };

            context.HttpContext.Response.Cookies.Add(cultureCookie);
        }

    }
}