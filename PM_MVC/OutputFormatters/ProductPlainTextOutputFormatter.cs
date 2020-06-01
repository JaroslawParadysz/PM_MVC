using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using PM_MVC.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace PM_MVC.OutputFormatters
{
    public class ProductPlainTextOutputFormatter : TextOutputFormatter
    {
        public ProductPlainTextOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/plain"));
            SupportedEncodings.Add(System.Text.Encoding.UTF8);
            SupportedEncodings.Add(System.Text.Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type)
        {
            if (typeof(ProductViewModel).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }

        public async override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, System.Text.Encoding selectedEncoding)
        {
            var response = context.Object;
            ExpandoObject eo = new ExpandoObject();
            IDictionary<string, object> deo = (IDictionary<string, object>)eo;
            foreach(var property in context.Object.GetType().GetProperties())
            {
                deo.Add(property.Name, property.GetValue(context.Object));
            }
            await context.HttpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(eo));
        }
    }
}
