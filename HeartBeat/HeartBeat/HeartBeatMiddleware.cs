using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

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
                
            }
            else
            {
                await _next(httpContext);
            }            
        }

        private Task CheckStatus(HttpContext httpContext)
        {
            var content = JsonConvert.SerializeObject(new ServerStatus(httpContext.Response.StatusCode));          
            return httpContext.Response.WriteAsync(content);
        }

        public class ServerStatus
        {
           public ServerStatus(int Status)
           {
                HttpStatus = Status;
           }
           public int HttpStatus { get; }
        }
    }
}
