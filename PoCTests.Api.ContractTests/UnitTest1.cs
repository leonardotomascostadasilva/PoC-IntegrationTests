using PactNet;
using System.Net;
using System.Net.Http.Json;
using FluentAssertions;

public sealed class UnitTest1
{
    private readonly IPactBuilderV3 _pactBuilder;
    public UnitTest1()
    {
        var pact = Pact.V3("MyAPI consumer", "MyAPI", new PactConfig());
        _pactBuilder = pact.WithHttpInteractions();
    }
    [Fact]
    public async Task Test1()
    {
        _pactBuilder
            .UponReceiving("A request to test")
                .Given("test")
                .WithRequest(HttpMethod.Get, "/v1/test")
                .WithHeader("id","12345")
            .WillRespond()
                .WithStatus(HttpStatusCode.OK)
                .WithJsonBody(new Output
                {
                    Id = "tester",
                    FirstName = "Totally",
                    LastName = "Awesome"
                });

        await _pactBuilder.VerifyAsync(async ctx =>
        {
            //Arrange
            var expectedResult = new Output
            {
                Id = "tester",
                FirstName = "Totally",
                LastName = "Awesome"
            };

            //Act
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("id", "12345");
            httpClient.BaseAddress = ctx.MockServerUri;
            var r = await httpClient.GetFromJsonAsync<Output>($"/v1/test");

            //Assert
            r.Should().BeEquivalentTo(expectedResult);
        });
    }
}

public class Output
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}