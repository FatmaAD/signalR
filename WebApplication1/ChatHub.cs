using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebApplication1
{
    public class ChatHub : Hub
    {
        public void NewMessage(string name, string msg)
        {
            Clients.All.OnMessage(name, msg);
        }

        public void JoinGroup (string name, string groupN)
        {
            Groups.Add(Context.ConnectionId, groupN);
            Clients.OthersInGroup(groupN).onMessage(name, "Just joined the group");
        }

        public void SendTogroup(string name, string gName, string msg)
        {
            Clients.Group(gName).onMessage(name, msg);
        }
    }
}