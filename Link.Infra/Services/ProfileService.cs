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
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository) 
        {
            _profileRepository = profileRepository;
        }

        public async Task CreateUserProfile(linkUserDto profile)
        {
             await _profileRepository.CreateUserProfile(profile);
        }

        public async Task<linkUserDto> GetUserProfile(decimal user_id)
        {
            return await _profileRepository.GetUserProfile(user_id);
        }

        public async Task UpdateUserProfile(linkUserDto profile)
        {
            await _profileRepository.UpdateUserProfile(profile);
        }
    }
}
