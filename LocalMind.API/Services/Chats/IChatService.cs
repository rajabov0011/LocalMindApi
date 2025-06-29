using LocalMind.API.Models.Chats;

namespace LocalMind.API.Services.Chats
{
    public interface IChatService
    {
        IQueryable<Chat> RetrieveAllChatsByUserId(Guid userId);
    }
}
