using Microsoft.AspNetCore.Builder;

namespace HeartBeat
{
    public static class HeartBeatMiddlewareExtension
    {
        public static IApplicationBuilder UseHeartBeat(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HeartBeatMiddleware>();
        }

        public static IApplicationBuilder UseHeartBeat(this IApplicationBuilder builder, string connectionString)
        {
            return builder.UseMiddleware<HeartBeatMiddleware>(connectionString);
        }
    }
}
