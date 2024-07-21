using WireMock.Server;
using WireMock.Settings;

namespace PoCTests.Api.IntegrationTest.Commons
{
    public class MockServerFixture
    {
        private readonly WireMockServer _wireMockServer;
        public readonly GetApiFixture GetApiFixture;

        public MockServerFixture()
        {
            _wireMockServer = WireMockServer.Start(new WireMockServerSettings
            {
                Urls = ["http://+:8085"],
                StartAdminInterface = true
            });

            GetApiFixture = new GetApiFixture(_wireMockServer);

        }

        public void Reset()
        {
            _wireMockServer.ResetMappings();
        }
    }
}
