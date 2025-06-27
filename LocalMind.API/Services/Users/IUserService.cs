using LocalMind.API.Models.Users;

namespace LocalMind.API.Services.Users
{
    public interface IUserService
    {
        ValueTask<User> AddUserAsync(User user);
        IQueryable<User> RetrieveAllUsers();
    }
}
