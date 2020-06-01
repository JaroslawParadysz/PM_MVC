using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PM_MVC.Filters.ExceptionFilters
{
    public class ProductCustomExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public ProductCustomExceptionFilter(
            IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }

        public override void OnException(ExceptionContext context)
        {
            var filterResult = new ViewResult { ViewName = "Error" };
            filterResult.ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(
                _modelMetadataProvider,
                context.ModelState);
            filterResult.ViewData.Add("ExceptionMessage", context.Exception.Message);
            filterResult.ViewData.Add("ExceptionStackTrace", context.Exception.StackTrace);

            context.Result = filterResult;
        }
    }
}
