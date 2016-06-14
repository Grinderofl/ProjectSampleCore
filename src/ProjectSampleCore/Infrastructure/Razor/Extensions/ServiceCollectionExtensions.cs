using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using ProjectSampleCore.Infrastructure.Razor.ViewEngine;

namespace ProjectSampleCore.Infrastructure.Razor.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureViewEngineToLookUnderFeatures(this IServiceCollection services)
            => services.Configure<RazorViewEngineOptions>(r =>
            {
                r.UseFeaturesFolder();
            });

        public static RazorViewEngineOptions UseFeaturesFolder(this RazorViewEngineOptions options)
        {
            options.ViewLocationExpanders.Add(new AreasToFeaturesViewLocationExpander());
            return options;
        }
    }
}
