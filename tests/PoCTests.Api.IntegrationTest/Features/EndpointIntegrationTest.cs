using AutoFixture;
using FluentAssertions;
using PoCTests.Api.Features.Login;
using PoCTests.Api.IntegrationTest.Commons;
using System.Net;
using System.Text.Json;

namespace PoCTests.Api.IntegrationTest.Features
{
    [Collection(name: nameof(CustomWebApplicationFactoryCollection))]
    public class EndpointIntegrationTest(HelperFixture helperFixture)
    {
        private readonly Fixture _fixture = new();

        [Fact]
        public async Task GetEndpoint_GivenRequestReceived_ThenReturnsOKWithHelloWorldContent()
        {
            // Arrange
            var expectedResponse = _fixture
                .Build<LoginResponse>()
                .With(e => e.Description, "\"Hello-World\"")
                .Create();

            helperFixture.MockServerFixture.GetApiFixture.Execute(
                path: "/api/v1/validate",
                statusCode: HttpStatusCode.OK,
                response: "Hello-World");

            // Act
            var httpResponseMessage = await helperFixture.Client.GetAsync("/v1/login");

            // Assert
            var response = await httpResponseMessage.DeserializeAsync<LoginResponse>();
            response.Should().NotBeNull();
            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
