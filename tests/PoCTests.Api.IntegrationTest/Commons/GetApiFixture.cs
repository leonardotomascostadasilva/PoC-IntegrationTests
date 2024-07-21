using System.Net;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace PoCTests.Api.IntegrationTest.Commons
{
    public class GetApiFixture(WireMockServer wireMockServer)
    {
        private readonly WireMockServer _wireMockServer = wireMockServer;

        public void Execute(string path, HttpStatusCode statusCode, object? response = null)
        {
            if (response is not null)
            {
                _wireMockServer
               .Given(Request
                   .Create()
                   .WithPath(path)
                   .UsingGet())
               .RespondWith(Response
                   .Create()
                   .WithBodyAsJson(response)
                   .WithStatusCode(statusCode));
            }
            else
            {
                _wireMockServer
               .Given(Request
                   .Create()
                   .WithPath(path)
                   .UsingGet())
               .RespondWith(Response
                   .Create()
                   .WithStatusCode(statusCode));
            }
        }
    }
}
