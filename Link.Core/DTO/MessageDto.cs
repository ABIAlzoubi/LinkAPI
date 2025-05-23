using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Core.DTO
{
    public class MessageDto
    {
        public decimal message_id {  get; set; }
        public string? content { get; set; }
        public DateTime sent_at { get; set; }
        public DateTime deleted_at { get; set; }
        public String? is_deleted { get; set; }
        public decimal? deleter_id { get; set; }
        public decimal? reply_to_message_id { get; set; }
        public decimal sender_id { get; set; }
        public String? sender_username { get; set; }
        public String? sender_Pic { get; set; }
        public String? status { get; set; }
        public DateTime status_updated_at { get; set; }
        public String? Replayed_Message { get; set; }
        public List<ReactionsDto>? reactions { get; set; }

    }
}
