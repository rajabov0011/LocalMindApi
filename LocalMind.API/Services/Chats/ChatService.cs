using LocalMind.API.Models.Chats;
using LocalMind.API.Repositories.Chats;

namespace LocalMind.API.Services.Chats
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            this.chatRepository = chatRepository;
        }

        public IQueryable<Chat> RetrieveAllChatsByUserId(Guid userId)
        {
            return this.chatRepository.SelectAllChats()
                .Where(Chat => Chat.UserId == userId)
                .OrderByDescending(Chat => Chat.CreatedDate);
        }
    }
}
