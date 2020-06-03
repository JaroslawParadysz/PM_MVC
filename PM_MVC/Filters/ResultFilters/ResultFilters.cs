using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM_MVC.Filters.ResultFilters
{
    public class ResultFilters : ResultFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var res = context.Result;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var res = context.Result;
            context.HttpContext.Response.Headers["result-filters"] = "action-executing";
        }
    }
}
