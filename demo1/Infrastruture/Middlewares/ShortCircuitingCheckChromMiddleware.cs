using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo1.Infrastruture.Middlewares
{
    public class ShortCircuitingCheckChromMiddleware
    {
        private RequestDelegate nextDelegate;

        public ShortCircuitingCheckChromMiddleware(RequestDelegate requestDelegate)
        {
            nextDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //!httpContext.Request.IsHttps Check It
            if (!httpContext.Request.Headers["user-agent"].ToString().Contains("Chrome"))
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
