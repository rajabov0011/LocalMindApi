using LocalMind.API.DataContext;
using LocalMind.API.Models.ChatDetails;

namespace LocalMind.API.Repositories.ChatDetails
{
    public class ChatDetailRepository : IChatDetailRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ChatDetailRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async ValueTask<ChatDetail> InserChatDetailAsync(ChatDetail chatDetail)
        {
            await this.dbContext.ChatDetails.AddAsync(chatDetail);
            await this.dbContext.SaveChangesAsync();

            return chatDetail;
        }

        public IQueryable<ChatDetail> SelectAllChatDetails()
        {
            return this.dbContext.ChatDetails
                .OrderByDescending(chatDetail => chatDetail.CreatedDate);
        }

        public async ValueTask<ChatDetail> UpdateChatDetailAsync(ChatDetail chatDetail)
        {
            this.dbContext.ChatDetails.Update(chatDetail);
            await this.dbContext.SaveChangesAsync();

            return chatDetail;
        }
    }
}
