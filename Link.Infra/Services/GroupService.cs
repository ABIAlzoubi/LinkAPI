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
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task CreateGroup(decimal userId, string groupName, string groupMembersId)
        { 
            await _groupRepository.CreateGroup(userId, groupName, groupMembersId);
        }
        public async Task ChangeGroupName(decimal groupId, string newName)
        {
            await _groupRepository.ChangeGroupName(groupId, newName);
        }
        public async Task<List<GroupMembersDto>> getGroupMembers(decimal groupId)
        {
            return await _groupRepository.getGroupMembers(groupId);
        }
        public async Task AddAdmin(decimal userId, decimal newAdminId, decimal groupId)
        {
            await _groupRepository.AddAdmin(userId, newAdminId, groupId);
        }
        public async Task RemoveAdmin(decimal userId, decimal removeAdminId, decimal groupId)
        {
            await _groupRepository.RemoveAdmin(userId,removeAdminId, groupId);
        }
        public async Task AddMemberToGroup(decimal newUserId, decimal groupId)
        {
            var mempers = await _groupRepository.getGroupMembers(groupId);
            var isMember = mempers.Any(x=> x.userid == newUserId);
            if (isMember) 
                throw new InvalidOperationException("User is already a member of the group.");
            
            await _groupRepository.AddMemberToGroup(newUserId, groupId);

        }
        public async Task RemoveMemberFromGroup(decimal adminId, decimal userToRemove, decimal groupId)
        {
            var mempers = await _groupRepository.getGroupMembers(groupId);
            var isMember = mempers.Any(x => x.userid == userToRemove);
            if (!isMember)
                throw new InvalidOperationException("User is not a member of the group.");
            await _groupRepository.RemoveMemberFromGroup(adminId, userToRemove, groupId);
        }
    }
}
