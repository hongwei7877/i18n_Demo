using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace i18n_Demo.Extensions {
    public static class IEnumerableExtensions {
        /// <summary>
        /// Convert IEnumerable to IList
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">目標</param>
        /// <param name="text">文字</param>
        /// <param name="value">值</param>
        /// <param name="isOrder">排序</param>
        /// <returns></returns>
        public static IList<SelectListItem> ToSelectList<T>(
            this IEnumerable<T> source, Func<T, object> text, Func<T, object> value, bool isOrder = false) {
            return source.ToSelectList(text, value, null, null);
        }
        /// <summary>
        /// Convert IEnumerable to IList
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">目標</param>
        /// <param name="text">文字</param>
        /// <param name="value">值</param>
        /// <param name="optionalText">新增至第一筆文字</param>
        /// <param name="isOrder">排序</param>
        /// <returns></returns>
        public static IList<SelectListItem> ToSelectList<T>(
            this IEnumerable<T> source, Func<T, object> text, Func<T, object> value,
            string optionalText, bool isOrder = false) {
            return source.ToSelectList(text, value, null, optionalText, isOrder);
        }

        /// <summary>
        /// Convert IEnumerable to IList<SelectListItem>
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">目標</param>
        /// <param name="text">文字</param>
        /// <param name="value">值</param>
        /// <param name="selected">選中的item</param>
        /// <param name="optionalText">新增至第一筆文字</param>
        /// <returns>IList of SelectListItem</returns>
        public static IList<SelectListItem> ToSelectList<T>(
            this IEnumerable<T> source, Func<T, object> text, Func<T, object> value,
            Func<T, bool> selected, string optionalText, bool isOrder = false) {
            return source.ToSelectList(text, value, selected, optionalText, string.Empty, isOrder);
        }

        /// <summary>
        /// Core function for EnumerableExtension.cs
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">目標</param>
        /// <param name="text">文字</param>
        /// <param name="value">值</param>
        /// <param name="selected">選中的item</param>
        /// <param name="optionalText">新增至第一筆文字</param>
        /// <param name="optionalValue">新增至第一筆值</param>
        /// <returns></returns>
        private static IList<SelectListItem> ToSelectList<T>(
            this IEnumerable<T> source, Func<T, object> text, Func<T, object> value,
            Func<T, bool> selected, string optionalText, string optionalValue, bool isOrder = false) {
            var items = new List<SelectListItem>();

            //預設會先加入optionalText
            if (!string.IsNullOrEmpty(optionalText)) {
                items.Insert(0, new SelectListItem() { Text = optionalText, Value = optionalValue });
            }

            if (source == null) {
                return items;
            }

            foreach (var entity in source) {
                var item = new SelectListItem();
                item.Text = text(entity).ToString();
                item.Value = value(entity).ToString();
                if (selected != null) {
                    item.Selected = selected(entity);
                }

                if (item.Value != optionalValue) {
                    items.Add(item);
                }
            }

            if (isOrder) {
                items = items.OrderBy(d => d.Text).ToList();
            }

            return items;
        }
    }
}