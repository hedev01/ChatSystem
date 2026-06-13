using ChatSystem.Application.DTO;
using ChatSystem.Application.Interfaces;
using ChatSystem.Domain.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace ChatSystem.Api.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
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
            var userId = Context.GetHttpContext()?.Request.Query["userId"];

            Console.WriteLine(
                $"Connected => {Context.ConnectionId} User => {userId}"
            );

            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine(
                $"Disconnected => {Context.ConnectionId}"
            );

            await base.OnDisconnectedAsync(exception);
        }
    }
}
