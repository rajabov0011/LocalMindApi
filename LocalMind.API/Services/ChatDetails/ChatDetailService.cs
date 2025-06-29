using LocalMind.API.Models.ChatDetails;
using LocalMind.API.Models.Chats;
using LocalMind.API.Repositories.ChatDetails;
using LocalMind.API.Repositories.Chats;

namespace LocalMind.API.Services.ChatDetails
{
    public class ChatDetailService : IChatDetailService
    {
        private readonly IChatDetailRepository chatDetailRepository;
        private readonly IChatRepository chatRepository;

        public ChatDetailService(
            IChatDetailRepository chatDetailRepository, 
            IChatRepository chatRepository)
        {
            this.chatDetailRepository = chatDetailRepository;
            this.chatRepository = chatRepository;
        }

        public async ValueTask<ChatDetail> AddChatDetailAsync(ChatDetail chatDetail, Guid userId)
        {
            Chat maybeChat = this.chatRepository.SelectAllChats()
                .FirstOrDefault(c => c.Id == chatDetail.ChatId);

            if (maybeChat is null)
            {
                var newChat = new Chat
                {
                    Id = chatDetail.ChatId,
                    CreatedDate = DateTime.UtcNow,
                    Name = chatDetail.Source.Substring(0, 5),
                    UserId = userId
                };

                await this.chatRepository.InserChatAsync(newChat);
            }

            await this.chatDetailRepository.InserChatDetailAsync(chatDetail);

            return chatDetail;
        }
    }
}
