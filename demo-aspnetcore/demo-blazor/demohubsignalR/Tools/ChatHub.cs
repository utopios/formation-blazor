using Microsoft.AspNetCore.SignalR;

namespace demohubsignalR.Tools;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    
}