using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Core.DTO
{
    public class linkUserDto
    {
        public decimal USERID { get; set; }
        public string? USERNAME { get; set; }
        public string? PHONE_NUMBER { get; set; }
        public string? EMAIL { get; set; }
        public string? HASHEDPASSWORD { get; set; }
        public string? PROFILEPIC { get; set; }
        public DateTime? CREATED_AT { get; set; }
        public string? IS_ACTIVE { get; set; }
    }
}
