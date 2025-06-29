using LocalMind.API.Models.Chats;

namespace LocalMind.API.Models.ChatDetails
{
    public class ChatDetail
    {
        public Guid Id { get; set; }
        public string Source { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
