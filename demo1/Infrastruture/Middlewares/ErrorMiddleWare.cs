using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo1.Infrastruture.Middlewares
{
    public class ErrorMiddleWare
    {
        private RequestDelegate nextDelegate;

        public ErrorMiddleWare(RequestDelegate requestDelegate)
        {
            nextDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await nextDelegate.Invoke(httpContext);
            if (httpContext.Response.StatusCode==400)
            {
                await httpContext.Response.WriteAsync("Bad Request");
            }
            else if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response.WriteAsync("Not Found !!!!");
            }


        }

    }
}


