using FluentAssertions;
using PoCTests.Api.IntegrationTest.Commons;
using System.Net;

namespace PoCTests.Api.IntegrationTest.Features
{
    [Collection(name: nameof(CustomWebApplicationFactoryCollection))]
    public class EndpointIntegrationTest(HelperFixture helperFixture)
    {
        [Fact]
        public async Task GetEndpoint_GivenRequestReceived_ThenReturnsOKWithHelloWorldContent()
        {
            // Arrange
            helperFixture.MockServerFixture.GetApiFixture.Execute(
                path: "/api/v1/validate",
                statusCode: HttpStatusCode.OK,
                response: "Hello World!");

            // Act
            var response = await helperFixture.Client.GetAsync("/v1/login");

            // Assert
            var result = await response.Content.ReadAsStringAsync();
            result.Should().Be("\"\\\"Hello World!\\\"\"");
        }
    }
}
