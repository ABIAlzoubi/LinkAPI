using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Core.DTO
{
    public class ChatDto
    {
        public decimal chat_id {  get; set; }
        public string name { get; set; }
        public char is_active { get; set; }
        public string content { get; set; }
        public DateTime sent_at { get; set; }
    }
}
