using HeartBeat;
using Microsoft.AspNetCore.Http;
using Moq;
using System.IO;
using Xunit;

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
    }
}
