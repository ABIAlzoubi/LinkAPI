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

        public Task<List<ActiveUsersDto>> GetActiveUsers(decimal userID)
        {
            return _homeScreenRepository.GetActiveUsers(userID);
        }
        public Task<linkUserDto> searchForUser(String userName)
        {
            return _homeScreenRepository.searchForUser(userName);
        }
        public Task<List<ChatDto>> GetAllChatsByuserID(decimal userID)
        { 
            return _homeScreenRepository.GetAllChatsByuserID(userID);
        }
        public Task<List<UnreadedMessagesCountDto>> GetAllUnreadMessagesCount(decimal userID)
        {
            return _homeScreenRepository.GetAllUnreadMessagesCount(userID);
        }
    }
}
