using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace HeartBeat
{
    public static class HeartBeatMiddlewareExtension
    {
        public static IApplicationBuilder UseHeartBeat(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HeartBeatMiddleware>();
        }

        public static IApplicationBuilder UseHeartBeat(this IApplicationBuilder builder, DbContext dbContext)
        {
            string connectionString = dbContext.Database.GetDbConnection().ConnectionString;
            return builder.UseMiddleware<HeartBeatMiddleware>(connectionString);
        }
    }
}
