using Refit;

namespace PoCTests.Api
{
    public interface IValidate
    {
        [Get("/api/v1/validate")]
        Task<IApiResponse<string?>> ValidateAsync();
    }
}
