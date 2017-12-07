using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeartBeat
{
    public static class HeartBeatMIddlewareExtension
    {
        public static IApplicationBuilder UseHeartBeat(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HeartBeatMiddleware>();
        }
    }
}
