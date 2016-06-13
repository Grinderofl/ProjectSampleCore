using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;

namespace ProjectSampleCore.Infrastructure.Razor.ViewEngine
{
    /// <summary>
    /// Changes the location of views from Areas root to Features root. Based on
    /// https://gist.github.com/michaelvolz/13a21d8a91755a7c2d62#file-aspnet5-beta6-examples-featurefolders-app-featurefolders-featurefolderlocationremapper-cs
    /// </summary>
    public class AreasToFeaturesViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
            => viewLocations.Select(x => x
                .Replace("/Areas/", "/Features/")
                .Replace("/Shared/", "/_Shared/")
            );
    }
}
