using Link.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Core.Services
{
    public interface IHomeScreenService
    {
        public Task<List<ActiveUsersDto>> GetActiveUsers(decimal userID);
        public Task<List<ActiveUsersDto>> searchForUser(String userName);
        public Task<List<ChatDto>> GetAllChatsByuserID(decimal userID);
        public Task<List<UnreadedMessagesCountDto>> GetAllUnreadMessagesCount(decimal userID);
    }
}
