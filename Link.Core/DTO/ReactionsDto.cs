using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Core.DTO
{
    public class ReactionsDto
    {
        public decimal? message_id { get; set; }
        public string reaction_type {  get; set; }
        public decimal reacted_by_user_id { get; set; }
        public string reacted_by_username { get; set; }
        public string reactor_Pic { get; set; }
    }
}
