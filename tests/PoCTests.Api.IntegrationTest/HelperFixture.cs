namespace PoCTests.Api.IntegrationTest
{
    public class HelperFixture
    {
        private readonly CustomWebApplicationFactory _webApplicationFactory = new();
        public readonly MockServerFixture MockServerFixture = new();
        public HttpClient Client => _webApplicationFactory.Server.CreateClient();
    }
}
