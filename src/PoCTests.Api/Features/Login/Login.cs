namespace PoCTests.Api.Features.Login
{
    public class LoginResponse
    {
        public string? Description { get; set; }
    }
    public interface ILogin
    {
        public Task<LoginResponse?> ExecuteAsync();
    }
    public class Login : ILogin
    {
        private readonly IValidate _validate;

        public Login(IValidate validate)
        {
            _validate = validate;
        }

        public async Task<LoginResponse?> ExecuteAsync()
        {
            var response = await _validate.ValidateAsync();

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return new LoginResponse { Description = response.Content };
        }
    }
}
