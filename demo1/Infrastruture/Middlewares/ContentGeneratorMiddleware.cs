using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo1.Infrastruture.Middlewares
{
    public class ContentGeneratorMiddleware
    {

        private RequestDelegate nextDelegate;

        public ContentGeneratorMiddleware(RequestDelegate requestDelegate)
        {
            nextDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Query["country"].ToString().ToLower()=="ir")
            {
               
                await httpContext.Response.WriteAsync("Hello From Iran");
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }

    }
}
