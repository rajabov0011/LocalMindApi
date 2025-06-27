using LocalMind.API.Models.UserCredentials;
using LocalMind.API.Models.UserTokens;
using LocalMind.API.Services.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace LocalMind.API.Controllers
{
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        [HttpPost("api/login")]
        public async ValueTask<ActionResult<UserToken>> LoginAsync([FromBody] UserCredential userCredential)
        {
            UserToken userToken =
                await this.accountService.LoginAsync(userCredential);

            return Ok(userToken);
        }
    }
}
