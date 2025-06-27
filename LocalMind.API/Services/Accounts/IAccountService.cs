using LocalMind.API.Models.UserCredentials;
using LocalMind.API.Models.UserTokens;

namespace LocalMind.API.Services.Accounts
{
    public interface IAccountService
    {
        ValueTask<UserToken> LoginAsync(UserCredential userCredential);
    }
}
