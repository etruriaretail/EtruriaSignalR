using EtruriaSignalR.Hub;
using EtruriaSignalR.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EtruriaSignalR.Controller
{
    [Route("etruriapi/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        private readonly IHubContext<ChatHub> hubContext;

        public ChatController(IHubContext<ChatHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        [Route("send")]
        [HttpPost]
        public async Task SendMessage(ChatMessage message)
        {
            //additional business logic 

            await this.hubContext.Clients.All.SendAsync("messageReceivedFromApi", message);

            //additional business logic 
        }        

        [Route("userlist")]
        [HttpGet]
        public async Task<ActionResult> UserList()
        {
            //additional business logic 

            try
            {
                return Ok(UserHandler.ConnectedIds);
            }catch (Exception e)
            {
                return BadRequest(e);
            }
            

            //additional business logic 
        }
    }
}
