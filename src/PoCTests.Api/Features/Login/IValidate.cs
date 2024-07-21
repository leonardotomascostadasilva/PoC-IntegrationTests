using Refit;

namespace PoCTests.Api.Features.Login
{
    public interface IValidate
    {
        [Get("/api/v1/validate")]
        Task<IApiResponse<string>> ValidateAsync();
    }
}
