using ChatSystem.Application.DTO;
using ChatSystem.Application.Interfaces;
using ChatSystem.Domain.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace ChatSystem.Api.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;
        private readonly IPresenceService _presenceService;
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(IChatService chatService , IPresenceService presenceService , ILogger<ChatHub> logger)
        {
            _chatService = chatService;
            _presenceService = presenceService;
            _logger = logger;
        }
        public async Task SendMessage(SendMessageRequest request)
        {
            await _chatService.SendMessage(new MessageDto
            {
                SenderId = request.SenderId,
                ReceiverId = request.ReceiverId,
                Content = request.Content
            });

            await Clients.Users(request.ReceiverId.ToString()).SendAsync("ReceiveMessage", request.SenderId, request.Content);
        }
        public override async Task OnConnectedAsync()
        {
            var userId = Context.GetHttpContext()?.Request.Query["userId"].ToString();

            if (string.IsNullOrEmpty(userId))
            {
                _logger.LogError("userId is null in OnConnectedAsync");
                return;
            }

            Context.Items["userId"] = userId;

            await _presenceService.UserConnected(userId, Context.ConnectionId);

            await Clients.Others.SendAsync("UserOnline", userId);

            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _logger.LogInformation("OnDisconnected");

            var userId = Context.Items["userId"]?.ToString();

            if (string.IsNullOrEmpty(userId))
            {
                _logger.LogError("userId is NULL in OnDisconnectedAsync");
                return;
            }

            _logger.LogInformation("UserId: {userId}", userId);

            var offline = await _presenceService.UserDisconnected(userId, Context.ConnectionId);

            _logger.LogInformation("offline = {offline}", offline);

            //if (offline)
            //{
                await Clients.Others.SendAsync("UserOffline", userId);
            //}

            await base.OnDisconnectedAsync(exception);
        }
    }
}
