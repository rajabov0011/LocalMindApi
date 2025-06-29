using LocalMind.API.Models.Chats;

namespace LocalMind.API.Repositories.Chats
{
    public interface IChatRepository
    {
        ValueTask<Chat> InserChatAsync(Chat chat);
        IQueryable<Chat> SelectAllChats();
    }
}
