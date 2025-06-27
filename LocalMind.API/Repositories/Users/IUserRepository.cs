using LocalMind.API.Models.Users;

namespace LocalMind.API.Repositories.Users
{
    public interface IUserRepository
    {
        ValueTask<User> InsertUserAsync(User user);
        IQueryable<User> SelectAllUsers();
    }
}
