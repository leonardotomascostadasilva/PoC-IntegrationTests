using System.Text.Json;

namespace PoCTests.Api.IntegrationTest.Commons
{
    public static class HttpResponseHelper
    {

        public static async Task<T?> DeserializeAsync<T>(this HttpResponseMessage httpResponseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var jsonResponse = await httpResponseMessage.Content.ReadAsStreamAsync();

            var response = JsonSerializer.Deserialize<T>(jsonResponse, options);

            return response;
        }
    }
}
