using LocalMind.API.Models.ChatDetails;
using LocalMind.API.Repositories.ChatDetails;
using LocalMind.API.Services.ChatDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LocalMind.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/chat-details")]
    public class ChatDetailsController : ControllerBase
    {
        private readonly IChatDetailService chatDetailService;

        public ChatDetailsController(IChatDetailService chatDetailService)
        {
            this.chatDetailService = chatDetailService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<ChatDetail>> PostChatDetailAsync(ChatDetail chatDetail)
        {
            Guid userId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            ChatDetail newChatDetail =
                await this.chatDetailService.AddChatDetailAsync(chatDetail, userId);

            return StatusCode(201, newChatDetail);
        }
    }
}
