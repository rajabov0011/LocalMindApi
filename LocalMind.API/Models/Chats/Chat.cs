using LocalMind.API.Models.ChatDetails;
using LocalMind.API.Models.Users;

namespace LocalMind.API.Models.Chats
{
    public class Chat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<ChatDetail> ChatDetails { get; set; }
    }
}
