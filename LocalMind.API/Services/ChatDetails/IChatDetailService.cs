using LocalMind.API.Models.ChatDetails;

namespace LocalMind.API.Services.ChatDetails
{
    public interface IChatDetailService
    {
        ValueTask<ChatDetail> AddChatDetailAsync(ChatDetail chatDetail, Guid userId);
    }
}
