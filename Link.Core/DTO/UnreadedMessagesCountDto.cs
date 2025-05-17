using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Core.DTO
{
    public class UnreadedMessagesCountDto
    {
        public decimal chat_id { get; set; }
        public decimal unread_count { get; set; }
    }
}
