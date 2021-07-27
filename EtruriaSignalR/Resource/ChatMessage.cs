using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtruriaSignalR.Resource
{
    public class ChatMessage
    {
        public string Text { get; set; }
        public string ConnectionId { get; set; }
        public DateTime Ts { get; set; }
    }
}

