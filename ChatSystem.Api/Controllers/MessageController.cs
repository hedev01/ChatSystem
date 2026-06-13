using ChatSystem.Api.Hubs;
using ChatSystem.Application.DTO;
using ChatSystem.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IChatService _chatService;

        public MessageController(IChatService chatService , IHubContext<ChatHub> hubContext)
        {
            _chatService = chatService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] MessageDto dto)
        {
            await _chatService.SendMessage(dto);

            return Ok();

        }
    }
}
