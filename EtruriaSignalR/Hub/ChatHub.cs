using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EtruriaSignalR.Resource;
using Microsoft.AspNetCore.SignalR;

namespace EtruriaSignalR.Hub
{
    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }

    public class ChatHub: Hub<IChatHub>
    {       
        //[HubMethodName("SendMessageToUser")]
        public async Task BroadcastAsync(ChatMessage message)
        {
            await Clients.All.MessageReceivedFromHub(message);
        }
        public override async Task OnConnectedAsync()
        {
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
            await Clients.All.NewUserConnected("a new user connectd ["+Context.ConnectionId+"]" + Context.User.Identity.Name);
        }
                
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            await Clients.All.UserDisconnected("user disconeect");
        }

    }

    public interface IChatHub
    {
        Task MessageReceivedFromHub(ChatMessage message);

        Task NewUserConnected(string message);

        Task UserDisconnected(string message);
    }
}
