namespace PoCTests.Api.IntegrationTest.Commons
{
    public class HelperFixture : IDisposable
    {
        private readonly CustomWebApplicationFactory _webApplicationFactory = new();
        public readonly MockServerFixture MockServerFixture = new();
        public HttpClient Client => _webApplicationFactory.Server.CreateClient();

        public void Dispose()
        {
            MockServerFixture.Reset();
        }
    }
}
