using Link.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Core.Services
{
    public interface IGroupService
    {
        public Task CreateGroup(decimal userId, string groupName, string groupMembersId);
        public Task ChangeGroupName(decimal groupId, string newName);
        public Task<List<GroupMembersDto>> getGroupMembers(decimal groupId);
        public Task AddAdmin(decimal userId, decimal newAdminId, decimal groupId);
        public Task RemoveAdmin(decimal userId, decimal removeAdminId, decimal groupId);
        public Task AddMemberToGroup(decimal newUserId, decimal groupId);
        public Task RemoveMemberFromGroup(decimal adminId, decimal userToRemove, decimal groupId);
    }
}
