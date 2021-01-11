using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo1.Infrastruture.Middlewares
{
    public class ContentEditMiddleware
    {
        private RequestDelegate nextDelegate;

        public ContentEditMiddleware(RequestDelegate requestDelegate)
        {
            nextDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //!httpContext.Request.IsHttps Check It
            if (httpContext.Session.GetString("sessoinObject")==null)
            {
                httpContext.Session.SetString("sessoinObject", "Create " + DateTime.Now);
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }

    }
}

