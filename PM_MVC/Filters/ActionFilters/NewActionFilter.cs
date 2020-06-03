using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using PM_MVC.Utils;
using System;
using System.Linq;

namespace PM_MVC.Filters.ActionFilters
{
    public class NewActionFilter : IActionFilter
    {
        private ITraceUtils _traceUtils;

        public NewActionFilter(ITraceUtils traceUtils)
        {
            _traceUtils = traceUtils;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _traceUtils.DoWork();
        }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            await session.LoadAsync();
            string data = null;
            if (session.Keys.Contains("MyKey"))
            {
                data = session.GetString("MyKey");
            }
            else
            {
                session.SetString("MyKey", "Data1");
            }
            
            _traceUtils.DoWork();
        }
    }
}
