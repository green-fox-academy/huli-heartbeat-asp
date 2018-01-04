using HeartBeat;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Data;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using System;
using System.Reflection;


namespace HeartBeatTest
{
    public class HttpResponse_Test
    {
        [Fact]
        public void Test()
        {
            //Arrange
            var httpRequestMock = new Mock<HttpRequest>();
                httpRequestMock.Setup(x => x.Scheme).Returns("http");
                httpRequestMock.Setup(x => x.Host).Returns(new HostString("localhost"));
                httpRequestMock.Setup(x => x.Path).Returns(new PathString("/heartbeat"));
                httpRequestMock.Setup(x => x.PathBase).Returns(new PathString(""));
                httpRequestMock.Setup(x => x.Method).Returns("GET");
                httpRequestMock.Setup(x => x.Body).Returns(new MemoryStream());
                httpRequestMock.Setup(x => x.QueryString).Returns(new QueryString("?"));
            var httpContextMock = new Mock<HttpContext>();
                 httpContextMock.Setup(x => x.Request).Returns(httpRequestMock.Object);
            var middlewareMock = new Mock<HeartBeatMiddleware>();
            //Act
            var result = httpRequestMock.Object.Path;
            //Assert
            Assert.Equal("/heartbeat", result);
        }

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
            //var startup = new Startup();

            //var webHostBuilder = new WebHostBuilder().ConfigureServices(options => options.AddDbContext<SimpleContext>(ops => ops.UseInMemoryDatabase("testdatabase")));

            //webHostBuilder.Configure(app => app.UseHeartBeat(simpleContext));

            var server = new TestServer(new WebHostBuilder().UseStartup<TestStartup>());

            var client = server.CreateClient();

            var result = await client.GetStringAsync("/heartbeat");

            Assert.Equal("{\"HttpStatus\":200,\"DbStatus\":true}", result);
        }
    }
}
