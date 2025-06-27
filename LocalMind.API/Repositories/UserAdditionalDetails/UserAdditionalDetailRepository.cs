
using LocalMind.API.DataContext;
using LocalMind.API.Models.UserAdditionalDetails;

namespace LocalMind.API.Repositories.UserAdditionalDetails
{
    public class UserAdditionalDetailRepository : IUserAdditionalDetailRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserAdditionalDetailRepository(ApplicationDbContext dbContext)
        {
            this.applicationDbContext = dbContext;
        }

        public async ValueTask<UserAdditionalDetail> InsertUserAdditionalDetailAsync(UserAdditionalDetail userAdditionalDetail)
        {
            await this.applicationDbContext.UserAdditionalDetails.AddAsync(userAdditionalDetail);

            return userAdditionalDetail;
        }
    }
}
