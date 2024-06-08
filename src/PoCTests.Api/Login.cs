
namespace PoCTests.Api
{
    public interface ILogin
    {
        public Task<string?> ExecuteAsync();
    }
    public class Login : ILogin
    {
        private readonly IValidate _validate;

        public Login(IValidate validate)
        {
            _validate = validate;
        }

        public async Task<string?> ExecuteAsync()
        {
            var response = await _validate.ValidateAsync();

            return response.IsSuccessStatusCode ? response.Content : null;
        }
    }
}
