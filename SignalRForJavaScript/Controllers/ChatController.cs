using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRForJavaScript.Hubs;
namespace SignalRForJavaScript.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : Controller
    {
        private readonly IHubContext<ChatHub> _hub;
        public ChatController(IHubContext<ChatHub> hub)
        {
            _hub = hub;
        }

        [HttpGet]
        public JsonResult Get()
        {
            _hub.Clients.All.SendAsync("ReceiveUpdate", $"时间：{DateTime.Now}");
            return this.Json("测试接口");
        }
    }
}