using System.Drawing;
using System.Diagnostics;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRForJavaScript.Hubs
{
  public class ChatHub : Hub
  {
    public async Task SendMessage(string user, string message)
    {
      await Clients.All.SendAsync("ReceiveMessage", user, message);
    }


    public override async Task OnConnectedAsync()
    {
      var id = Context.ConnectionId;
      Debug.WriteLine($"{DateTime.Now}【{id}】");
      await Clients.All.SendAsync("ReceiveLogin", new { Name = "系统消息", Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });
      // Console.WriteLine(id);
      await base.OnConnectedAsync();
    }

  }
}
