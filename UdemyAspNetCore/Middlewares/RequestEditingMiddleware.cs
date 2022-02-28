using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAspNetCore.Middlewares
{
    public class RequestEditingMiddleware
    {
        private RequestDelegate _requestDelegate;
        public RequestEditingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            // ysk.com.tr/yavuz
            if (context.Request.Path.ToString() == "/yavuz")
               await context.Response.WriteAsync("hosgeldin yavuz");
            else
                await _requestDelegate.Invoke(context);
        }

    }
}
