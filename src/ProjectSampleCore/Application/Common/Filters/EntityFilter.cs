using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjectSampleCore.Application.Common.Filters
{
    public class EntityFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            ((Controller) context.Controller).ViewBag.EntityType = context.RouteData.Values["controller"];
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }
    }
}
