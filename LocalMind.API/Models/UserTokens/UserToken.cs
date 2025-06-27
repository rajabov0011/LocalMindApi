using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace LocalMind.API.Models.UserTokens
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
