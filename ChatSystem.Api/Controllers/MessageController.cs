using ChatSystem.Application.DTO;
using ChatSystem.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IChatService _chatService;

        public MessageController(IChatService chatService)
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
