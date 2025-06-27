using LocalMind.API.Models.Users;
using LocalMind.API.Repositories.UserAdditionalDetails;
using LocalMind.API.Repositories.Users;

namespace LocalMind.API.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserAdditionalDetailRepository userAdditionalDetailRepository;

        public UserService(
            IUserRepository userRepository,
            IUserAdditionalDetailRepository userAdditionalDetailRepository)
        {
            this.userRepository = userRepository;
            this.userAdditionalDetailRepository = userAdditionalDetailRepository;
        }

        public async ValueTask<User> AddUserAsync(User user)
        {
            DateTime now = DateTime.UtcNow;

            user.CreatedDate = now;
            user.UpdatedDate = now;

            await this.userRepository.InsertUserAsync(user);

            if (user.UserAdditionalDetail != null)
            {
                await this.userAdditionalDetailRepository
                    .InsertUserAdditionalDetailAsync(user.UserAdditionalDetail);
            }

            return user;    
        }

        public IQueryable<User> RetrieveAllUsers()
        {
            return this.userRepository.SelectAllUsers();
        }
    }
}
