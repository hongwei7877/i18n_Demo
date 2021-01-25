using System;
using System.Web;

namespace i18n_Demo.Helper {
    public class CookieHelper {
        private CookieHelper() {

        }

        public static HttpCookie SetCookie(HttpRequestBase request, string culture) {

            HttpCookie cultureCookie = request.Cookies["_culture"];
            if (cultureCookie != null) {
                cultureCookie.Value = culture;
            }
            else {
                cultureCookie = new HttpCookie("_culture") {
                    Value = culture,
                    HttpOnly = true,
                    Expires = DateTime.MinValue
                };
            }
                

            return cultureCookie;
        }

    }
}