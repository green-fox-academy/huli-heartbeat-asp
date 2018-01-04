using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HeartBeat
{
    public class HeartBeatMiddleware
    {
        private readonly RequestDelegate next;
        private static readonly PathString path = new PathString("/heartbeat");
        private string connectionString;

        public HeartBeatMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public HeartBeatMiddleware(RequestDelegate next, string connectionString)
        {
            this.next = next;
            this.connectionString = connectionString;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.Equals(path))
            {
                await CheckStatus(httpContext);
            }
            else
            {
                await next(httpContext);
            }
        }

        public Task CheckStatus(HttpContext httpContext)
        {
            var content = JsonConvert.SerializeObject(new ServerStatus(httpContext.Response.StatusCode, ServerStatus.CheckDbStatus(connectionString)));
            return httpContext.Response.WriteAsync(content);

            //async-await
        }
    }
}
