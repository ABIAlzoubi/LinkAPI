using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Core.DTO
{
    public class SendMessageDto
    {
        public string? content { get; set; }
        public decimal? reply_to_message_id { get; set; }
        public decimal sender_id { get; set; }
        public decimal chat_id { get; set; }
    }
}
