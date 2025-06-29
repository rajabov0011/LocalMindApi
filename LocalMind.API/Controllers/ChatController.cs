using LocalMind.API.Models.Chats;
using LocalMind.API.Services.Chats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalMind.API.Controllers
{
    [Authorize]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService chatService;

        public ChatController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        [HttpGet("api/users/{userId}/chats")]
        public ActionResult<IQueryable<Chat>> GetAllChats(Guid userId)
        {
            IQueryable<Chat> chats = this.chatService.RetrieveAllChatsByUserId(userId);

            return Ok(chats);
        }
    }
}
