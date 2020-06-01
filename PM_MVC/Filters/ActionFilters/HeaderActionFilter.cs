using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace PM_MVC.Filters.ActionFilters
{
    public class HeaderActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers["author"] = "Jaroslaw Paradysz";
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var path = context.HttpContext.Request.Path;
        }
    }
}
