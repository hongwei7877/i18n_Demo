using System;
using System.ComponentModel;
using System.Reflection;

namespace i18n_Demo.Extensions {
    public static class EnumExtensions {
        /// <summary>
        /// 將Enum轉為數字
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int ToIntValue(this Enum self) {
            return Convert.ToInt16(self);
        }


        /// <summary>
        /// 取得Enum的描述標籤內容
        /// </summary>
        /// <returns></returns>
        public static string GetDescription(this Enum self) {
            FieldInfo fi = self.GetType().GetField(self.ToString());
            if (fi != null) {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0)
                    return attributes[0].Description;
            }

            return self.ToString();
        }
    }
}