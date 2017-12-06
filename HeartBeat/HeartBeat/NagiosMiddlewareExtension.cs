using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeartBeat
{
    public static class NagiosMiddlewareExtension
    {
        public static IApplicationBuilder UseNagios(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NagiosMiddleware>();
        }
    }
}
