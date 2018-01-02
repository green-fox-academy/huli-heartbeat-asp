using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using Xunit;
using System.Web;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HeartBeat;
using System.IO;

namespace HeartBeatTest
{
    public class HttpResponse_Test
    {
        //public Mock<HttpContext> contextMock { get; set; }
        //public Mock<HttpRequest> requestMock { get; set; }
        //public Mock<HeartBeatMiddleware> middlewareMock { get; set; }

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
            //middlewareMock.Invoke(httpContextMock.Object).Wait();
            //Assert
            middlewareMock.Verify(x => x.Invoke(httpContextMock.Object));
            Assert.Equal("/heartbeat", result);


            //Arrange
            //Mock<HttpContext> contextMock;
            //Mock<HttpRequest> requestMock = new Mock<HttpRequest>();
            //middlewareMock = new Mock<HeartBeatMiddleware>();
            //requestMock.Setup(x => x.Path).Returns(new PathString("/heartbeat"));
            //contextMock = new Mock<HttpContext>();
            //contextMock.SetupAllProperties();
            //var delgateMock = new Mock<RequestDelegate>();
            //contextMock.Setup(x => x.Request).Returns(requestMock.Object);

            //(next: (innerHttpContext) => Task.FromResult(0));
            //var HeartBeatMiddlewareMock = new HeartBeat.HeartBeatMiddleware(delgateMock.Object);
            //Act
            //await HeartBeatMiddlewareMock.Invoke(contextMock.Object);

            //var responseJson = HeartBeatMiddlewareMock.Invoke(contextMock.Object);
            //var responseJson2 = responseJson.ToString();
            //Assert
            //Assert.Equal("{\"HttpStatus\":200}", contextMock.Object.Request.Path);
            //middlewareMock.Verify(x => HeartBeatMiddlewareMock.Invoke(contextMock.Object));
            //contextMock.Verify(x => x. == "/heartbeat");
        }
    }
}
