using FluentAssertions;

namespace PoCTests.Api.IntegrationTest
{
    [Collection(name: nameof(CustomWebApplicationFactoryCollection))]
    public class EndpointIntegrationTest(HelperFixture helperFixture)
    {
        [Fact]
        public async Task GetEndpoint_GivenRequestReceived_ThenReturnsOKWithHelloWorldContent()
        {
            // Arrange
            helperFixture.MockServerFixture.ValidateApiFixture.ValidateMockResponse();

            // Act
            var response = await helperFixture.Client.GetAsync("/v1/login");

            // Assert
            var result = await response.Content.ReadAsStringAsync();
            result.Should().Be("\"Hello World!\"");
        }
    }
}
