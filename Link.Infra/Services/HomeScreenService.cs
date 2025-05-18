using Link.Core.DTO;
using Link.Core.Repository;
using Link.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Infra.Services
{
    public class HomeScreenService : IHomeScreenService
    {
        private readonly IHomeScreenRepository _homeScreenRepository;
        public HomeScreenService(IHomeScreenRepository homeScreenrepository)
        {
            _homeScreenRepository = homeScreenrepository;
        }

        public async Task<List<ActiveUsersDto>> GetActiveUsers(decimal userID)
        {
            return await _homeScreenRepository.GetActiveUsers(userID);
        }
        public async Task<linkUserDto> searchForUser(String userName)
        {
            return await _homeScreenRepository.searchForUser(userName);
        }
        public async Task<List<ChatDto>> GetAllChatsByuserID(decimal userID)
        { 
            return await _homeScreenRepository.GetAllChatsByuserID(userID);
        }
        public async Task<List<UnreadedMessagesCountDto>> GetAllUnreadMessagesCount(decimal userID)
        {
            return await _homeScreenRepository.GetAllUnreadMessagesCount(userID);
        }
    }
}
