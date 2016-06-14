using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ProjectSampleCore.Infrastructure.Mvc.Extensions
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Extension method to return a display template for provided type until Razor team fixes Html.DisplayFor() inside foreach
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="html"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static async Task<IHtmlContent> DisplayTemplateFor<T>(this IHtmlHelper html, T item)
            => await html.PartialAsync($"DisplayTemplates/{item.GetType().Name}", item);

        /// <summary>
        /// Extension method to return editor template for provided type until Razor team fixes Html.EditorFor() inside foreach
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="html"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static async Task<IHtmlContent> EditorTemplateFor<T>(this IHtmlHelper html, T item)
            => await html.PartialAsync($"EditorTemplates/{item.GetType().Name}", item);
    }
}
