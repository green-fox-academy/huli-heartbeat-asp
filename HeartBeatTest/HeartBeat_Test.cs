using HeartBeat;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Threading.Tasks;
using Xunit;


namespace HeartBeatTest
{
    public class HttpResponse_Test
    {
        [Fact]
        public async Task EmptyMiddleWareConstructorShouldReturnWithOKStatusCode()
        {
            var server = new TestServer(new WebHostBuilder().Configure(app => app.UseHeartBeat()));
            var client = server.CreateClient();

            var result = await client.GetAsync("/heartbeat");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task EmtpyStringMiddleWareConstructorShouldReturnWithFalseDbStatus()
        {
            var server = new TestServer(new WebHostBuilder().Configure(app => app.UseMiddleware<HeartBeatMiddleware>(string.Empty)));
            var client = server.CreateClient();

            var result = await client.GetStringAsync("/heartbeat");

            Assert.Equal("{\"HttpStatus\":200,\"DbStatus\":false}", result);
        }

        [Fact]
        public async Task FilledWithConnectionStringMiddleWareConstructorShouldReturnWithFalseDbStatus()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<TestStartup>());

            var client = server.CreateClient();
            
            var result = await client.GetStringAsync("/heartbeat");

            Assert.Equal("{\"HttpStatus\":200,\"DbStatus\":true}", result);
        }
    }
}
