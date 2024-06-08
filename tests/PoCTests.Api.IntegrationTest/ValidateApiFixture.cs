using System.Net;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace PoCTests.Api.IntegrationTest
{
    public class ValidateApiFixture
    {
        private readonly WireMockServer _wireMockServer;

        public ValidateApiFixture(WireMockServer wireMockServer)
        {
            _wireMockServer = wireMockServer;
        }

        public void ValidateMockResponse()
        {
            _wireMockServer
                .Given(Request
                    .Create()
                    .WithPath("/api/v1/validate")
                    .UsingGet())
                .RespondWith(Response
                    .Create()
                    .WithBody("Hello World!")
                    .WithStatusCode(HttpStatusCode.OK));
        }
    }
}
