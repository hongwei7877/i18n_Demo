using System.Web;

namespace i18n_Demo.Helper {
    public class SessionHelper {
        private SessionHelper() {

        }

        public static SessionHelper Current {
            get {
                SessionHelper session = (SessionHelper)HttpContext.Current.Session["Session"];
                if (session == null) {
                    session = new SessionHelper();
                    HttpContext.Current.Session["Session"] = session;
                }
                return session;
            }
        }

        public string Culture { get; set; }
    }
}