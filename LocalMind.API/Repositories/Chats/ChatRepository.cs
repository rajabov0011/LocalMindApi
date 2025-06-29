using LocalMind.API.DataContext;
using LocalMind.API.Models.Chats;

namespace LocalMind.API.Repositories.Chats
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext dbcontext;

        public ChatRepository(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async ValueTask<Chat> InserChatAsync(Chat chat)
        {
            await this.dbcontext.Chats.AddAsync(chat);
            await this.dbcontext.SaveChangesAsync();

            return chat;
        }

        public IQueryable<Chat> SelectAllChats()
        {
            return this.dbcontext.Chats;
        }
    }
}
