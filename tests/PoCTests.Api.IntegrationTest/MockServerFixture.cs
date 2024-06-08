using WireMock.Server;
using WireMock.Settings;

namespace PoCTests.Api.IntegrationTest
{
    public class MockServerFixture
    {
        private readonly WireMockServer _wireMockServer;
        public readonly ValidateApiFixture ValidateApiFixture;

        public MockServerFixture()
        {
            _wireMockServer = WireMockServer.Start(new WireMockServerSettings
            {
                Urls = new []{"http://+:8085"},
                StartAdminInterface = true
            });

            ValidateApiFixture = new ValidateApiFixture(_wireMockServer);

        }

        public void Reset()
        {
            _wireMockServer.ResetMappings();
        }
    }
}
