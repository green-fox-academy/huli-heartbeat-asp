using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HeartBeat
{
    public class HeartBeatMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly PathString path = new PathString("/heartbeat");
        private string connectionString;

        public HeartBeatMiddleware(RequestDelegate next, DbContext dbContext)
        {
            _next = next;
            connectionString = dbContext.Database.GetDbConnection().ConnectionString;
        }

        public async Task Invoke(HttpContext httpContext, string connectionString)
        {
            if (httpContext.Request.Path.Equals(path))
            {
                await CheckStatus(httpContext);
                CheckDbStatus(connectionString);
            }
            else
            {
                await _next(httpContext);
            }
        }

        public Task CheckStatus(HttpContext httpContext)
        {
            var content = JsonConvert.SerializeObject(new ServerStatus(httpContext.Response.StatusCode, CheckDbStatus(connectionString)));
            return httpContext.Response.WriteAsync(content);
        }

        public bool CheckDbStatus(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT 1";
                    var result = (bool)command.ExecuteScalar();
                    return result;
                }
            }  
        }
    }
}
