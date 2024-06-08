using Microsoft.AspNetCore.Mvc;

namespace PoCTests.Api
{
    [ApiController]
    [Route("v1/[controller]")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _login;

        public LoginController(ILogin login)
        {
            _login = login;
        }

        [HttpGet]
        public async Task<ActionResult> GetLogin()
        {
            return Ok(await _login.ExecuteAsync());
        }
    }

}

