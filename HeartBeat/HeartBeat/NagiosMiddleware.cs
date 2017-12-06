using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HeartBeat
{
    public class NagiosMiddleware
    {
        private readonly RequestDelegate _next;

        public NagiosMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/heartbeats"))
            {
                //await httpContext.Response.WriteAsync("/api/todo was handled");
                await _next(httpContext);
            }
            await _next(httpContext);
        }
    }
}
