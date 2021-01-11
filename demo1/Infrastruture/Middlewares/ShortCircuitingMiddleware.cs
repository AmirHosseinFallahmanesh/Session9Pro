using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo1.Infrastruture.Middlewares
{
    public class ShortCircuitingMiddleware
    {

        private RequestDelegate nextDelegate;

        public ShortCircuitingMiddleware(RequestDelegate requestDelegate)
        {
            nextDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //!httpContext.Request.IsHttps Check It
            if (httpContext.Request.IsHttps)
            {
                 httpContext.Response.StatusCode = 400;
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
