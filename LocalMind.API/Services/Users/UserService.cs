using LocalMind.API.Models.Users;
using LocalMind.API.Repositories.Users;

namespace LocalMind.API.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository) =>
            this.userRepository = userRepository;

        public async ValueTask<User> AddUserAsync(User user)
        {
            DateTime now = DateTime.UtcNow;

            user.CreatedDate = now;
            user.UpdatedDate = now;

            return await this.userRepository.InsertUserAsync(user);
        }

        public IQueryable<User> RetrieveAllUsers()
        {
            return this.userRepository.SelectAllUsers();
        }
    }
}
