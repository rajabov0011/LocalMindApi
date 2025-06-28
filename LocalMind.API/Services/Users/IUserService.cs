using LocalMind.API.DTOs;
using LocalMind.API.Models.Users;

namespace LocalMind.API.Services.Users
{
    public interface IUserService
    {
        ValueTask<UserDto> AddUserAsync(UserDto userDto);
        IQueryable<UserDto> RetrieveAllUsers();
    }
}
