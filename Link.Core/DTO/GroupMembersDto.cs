using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Core.DTO
{
    public class GroupMembersDto
    {
        public decimal userid { get; set; }
        public string? username { get; set; }
        public string? profilePic { get; set; }
        public DateTime joined_at { get; set; }
        public string? role_name { get; set; }
    }
}
