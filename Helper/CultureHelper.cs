using i18n_Demo.Extensions;
using i18n_Demo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace i18n_Demo.Helper {

    public class CultureHelper {
        public enum CultureEnum {
            /// <summary>
            /// 中文(繁體)
            /// </summary>
            [Description("zh-TW")]
            zhTW = 0,

            /// <summary>
            /// 中文(简体)
            /// </summary>
            [Description("zh-CN")]
            zhCN,

            /// <summary>
            /// 英文
            /// </summary>
            [Description("en-US")]
            enUS
        }

        /// <summary>
        /// 取得已對應的語言系(如果沒有對應的則以預設為主)
        /// </summary>
        /// <param name="culture">選擇的語系</param>
        /// <returns>對應的語系</returns>
        public static string GetImplementedCulture(string culture) {
            bool isImplemented = false;

            if (!string.IsNullOrEmpty(culture)) {
                isImplemented = GetAllImplementedCultures().Any(x => x.Value.ToLower().Equals(culture.ToLower())) ;
            }

            if (!isImplemented) {
                return GetDefaultCulture();
            }
            else {
                return culture;
            }
        }

        /// <summary>
        /// 取得所有有建立的語系
        /// </summary>
        /// <remarks>通常是給下拉式選單使用</remarks>
        /// <returns>語系集合</returns>
        public static IEnumerable<Culture> GetAllImplementedCultures() {
            List<Culture> cultureList = new List<Culture>();
            foreach (CultureEnum cl in Enum.GetValues(typeof(CultureEnum))) {
                cultureList.Add(new Culture {
                    Key = cl.ToIntValue(),
                    Value = cl.GetDescription()
                });

            }

            return cultureList.AsEnumerable<Culture>();
        }

        private static string GetDefaultCulture() {
            return CultureEnum.zhTW.GetDescription(); //預設為zh-TW 繁中
        }
    }
}