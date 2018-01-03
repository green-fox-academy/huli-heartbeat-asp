using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace HeartBeat
{
    public static class HeartBeatMiddlewareExtension
    {
        public static IApplicationBuilder UseHeartBeat(this IApplicationBuilder builder, DbContext dbContext)
        {
            return builder.UseMiddleware<HeartBeatMiddleware>();
        }
    }
}
