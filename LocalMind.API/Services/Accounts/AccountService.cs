using LocalMind.API.CustomExceptions;
using LocalMind.API.Helpers;
using LocalMind.API.Models.UserCredentials;
using LocalMind.API.Models.Users;
using LocalMind.API.Models.UserTokens;
using LocalMind.API.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LocalMind.API.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;

        public AccountService(
            IUserRepository userRepository,
            IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        public async ValueTask<UserToken> LoginAsync(UserCredential userCredential)
        {
            User maybeUser =
                await this.userRepository.SelectAllUsers()
                    .FirstOrDefaultAsync(user =>
                        user.Username == userCredential.Username);

            if (maybeUser is null)
            {
                throw new NotFoundException("User is not found with given username and password!");
            }

            bool isPasswordEqual =
                HashingHelper.IsHashValid(
                    userCredential.Password,
                    maybeUser.HashedPassword);

            if (isPasswordEqual is false)
            {
                throw new NotFoundException("User is not found with given username and password!");
            }

            return GenerateUserToken(maybeUser);
        }

        private UserToken GenerateUserToken(User user)
        {
            string secretKet = this.configuration["AuthConfiguration:Key"];
            string issuer = this.configuration["AuthConfiguration:Issuer"];
            string audience = this.configuration["AuthConfiguration:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKet));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("FullName", $"{user.FirstName} {user.LastName}")
            };

            DateTime expirationDate = DateTime.Now.AddMinutes(30);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expirationDate,
                signingCredentials: credentials);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserToken
            {
                Token = tokenString,
                ExpirationDate = expirationDate
            };
        }
    }
}
