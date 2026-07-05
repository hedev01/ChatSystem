using ChatSystem.Application.DTO;
using ChatSystem.Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace ChatSystem.Api.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;
        private readonly IPresenceService _presenceService;
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(
            IChatService chatService,
            IPresenceService presenceService,
            ILogger<ChatHub> logger)
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

            await Clients.Users(request.ReceiverId.ToString())
                .SendAsync("ReceiveMessage", request.SenderId, request.ReceiverId, request.Content);
        }

        public async Task MarkConversationAsRead(Guid senderId)
        {
            var receiverIdString = Context.Items["userId"]?.ToString();

            if (!Guid.TryParse(receiverIdString, out var receiverId))
                return;

            await _chatService.MarkConversationAsRead(senderId, receiverId);

            await Clients.User(senderId.ToString())
                .SendAsync("ConversationRead", receiverId);
        }


        public override async Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;

            _logger.LogInformation("🟢 CONNECTED | ConnectionId: {ConnectionId}", connectionId);

            var userId = Context.GetHttpContext()?.Request.Query["userId"].ToString();

            if (string.IsNullOrEmpty(userId))
            {
                _logger.LogWarning("❌ userId is NULL | ConnectionId: {ConnectionId}", connectionId);
                return;
            }


            Context.Items["userId"] = userId;

            _logger.LogInformation("👤 User Connected | UserId: {UserId}", userId);


            var isFirstConnection = await _presenceService.UserConnected(userId, connectionId);

            _logger.LogInformation("📌 Presence updated | IsFirstConnection: {IsFirst}", isFirstConnection);


            var onlineUsers = await _presenceService.GetOnlineUsers();

            _logger.LogInformation("📡 Online Users Snapshot Count: {Count}", onlineUsers.Count);

            foreach (var u in onlineUsers)
            {
                _logger.LogInformation("   🟢 ONLINE: {UserId}", u);
            }

            await Clients.Caller.SendAsync("OnlineUsers", onlineUsers);

            _logger.LogInformation("📤 Snapshot sent to caller");


            if (isFirstConnection)
            {
                await Clients.Others.SendAsync("UserOnline", userId);
                _logger.LogInformation("📣 Broadcast UserOnline: {UserId}", userId);
            }

            await base.OnConnectedAsync();
        }


        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var connectionId = Context.ConnectionId;

            _logger.LogInformation("🔴 DISCONNECTED | ConnectionId: {ConnectionId}", connectionId);

            var userId = Context.Items["userId"]?.ToString();

            if (string.IsNullOrEmpty(userId))
            {
                _logger.LogWarning("❌ userId NOT FOUND in Context.Items | ConnectionId: {ConnectionId}", connectionId);
                await base.OnDisconnectedAsync(exception);
                return;
            }

            _logger.LogInformation("👤 User Disconnecting | UserId: {UserId}", userId);


            var isLastConnection = await _presenceService.UserDisconnected(userId, connectionId);

            _logger.LogInformation("📌 Presence removed | IsLastConnection: {IsLast}", isLastConnection);


            if (isLastConnection)
            {
                await Clients.Others.SendAsync("UserOffline", userId);
                _logger.LogInformation("📣 Broadcast UserOffline: {UserId}", userId);
            }

            await base.OnDisconnectedAsync(exception);

            _logger.LogInformation("✅ DISCONNECT COMPLETE | UserId: {UserId}", userId);
        }
    }
}