using LocalMind.API.Models.ChatDetails;

namespace LocalMind.API.Repositories.ChatDetails
{
    public interface IChatDetailRepository
    {
        ValueTask<ChatDetail> InserChatDetailAsync(ChatDetail chatDetail);
        IQueryable<ChatDetail> SelectAllChatDetails();
        ValueTask<ChatDetail> UpdateChatDetailAsync(ChatDetail chatDetail);
    }
}
