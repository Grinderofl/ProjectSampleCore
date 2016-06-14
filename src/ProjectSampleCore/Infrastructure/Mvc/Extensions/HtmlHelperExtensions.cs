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
        public static async Task<IHtmlContent> DisplayTemplateFor<T>(this IHtmlHelper html, T item)
            => await html.PartialAsync($"DisplayTemplates/{item.GetType().Name}", item);

        public static async Task<IHtmlContent> EditorTemplateFor<T>(this IHtmlHelper html, T item)
            => await html.PartialAsync($"EditorTemplates/{item.GetType().Name}", item);
    }
}
