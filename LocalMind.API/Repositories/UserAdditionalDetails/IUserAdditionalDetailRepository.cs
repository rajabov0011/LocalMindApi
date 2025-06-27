using LocalMind.API.Models.UserAdditionalDetails;

namespace LocalMind.API.Repositories.UserAdditionalDetails
{
    public interface IUserAdditionalDetailRepository
    {
        ValueTask<UserAdditionalDetail> InsertUserAdditionalDetailAsync(
            UserAdditionalDetail userAdditionalDetail);
    }
}
