using Link.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Core.Services
{
    public interface IProfileService
    {
        public Task CreateUserProfile(linkUserDto profile);
        public Task<linkUserDto> GetUserProfile(decimal user_id);
        public Task UpdateUserProfile(linkUserDto profile);
    }
}
