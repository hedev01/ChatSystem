using Microsoft.AspNetCore.SignalR;

namespace ChatSystem.Api.SignalR
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            return connection.GetHttpContext()?.Request.Query["UserId"];
        }
    }
}
