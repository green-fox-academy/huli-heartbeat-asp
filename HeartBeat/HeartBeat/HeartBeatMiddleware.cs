using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HeartBeat
{
    public class HeartBeatMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly PathString path = new PathString("/heartbeat");

        public HeartBeatMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.Equals(path))
            {
                await CheckStatus(httpContext);
                return;
            }
            await _next(httpContext);
        }

        public Task CheckStatus(HttpContext httpContext)
        {
            var content = JsonConvert.SerializeObject("cup");
            return httpContext.Response.WriteAsync(content);
        }
    }
}
