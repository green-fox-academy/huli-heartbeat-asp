using Microsoft.AspNetCore.Http;
using Moq;
using System.IO;
using Xunit;
using HeartBeat;

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
            //Act
            var result = httpRequestMock.Object.Path;
            //Assert
            Assert.Equal("/heartbeat", result);
        }

        [Fact]
        public void SqlQueryShouldReturnWithTrue()
        {
            bool result = ServerStatus.CheckDbStatus(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;");

            Assert.Equal(true, result);
        }

        [Fact]
        public void SqlQueryShouldReturnWithFalse()
        {
            bool result = ServerStatus.CheckDbStatus(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=petike;Integrated Security=True;Connect Timeout=30;");

            Assert.Equal(false, result);
        }
    }
}
