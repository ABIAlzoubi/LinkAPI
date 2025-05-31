using Dapper;
using Link.Core.Common;
using Link.Core.DTO;
using Link.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Infra.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IDbContext _dbContext;
        public GroupRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateGroup(decimal userId, string groupName, string groupMembersId)
        {
            var dp = new DynamicParameters();
            dp.Add("p_created_by", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("p_chat_name", groupName, dbType: DbType.String, direction: ParameterDirection.Input);
            dp.Add("p_user_ids_csv", groupMembersId,dbType: DbType.String, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("HomeScreen_Package.CreateGroup", dp, commandType: CommandType.StoredProcedure);
        }


        public async Task ChangeGroupName(decimal groupId, string newName)
        {
            var dp = new DynamicParameters();
            dp.Add("c_id", groupId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("c_name", newName, dbType: DbType.String, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("HomeScreen_Package.ChangeGroupName", dp, commandType: CommandType.StoredProcedure);
        }


        public async Task<List<GroupMembersDto>> getGroupMembers(decimal groupId)
        {
            var dp = new DynamicParameters();
            dp.Add("c_id", groupId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<GroupMembersDto>("HomeScreen_Package.GetGroupMembers", dp, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task AddAdmin(decimal userId, decimal newAdminId, decimal groupId)
        {
            var dp = new DynamicParameters();
            dp.Add("u_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("newAdmin", newAdminId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("chatID", groupId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("HomeScreen_Package.AddAdmin", dp, commandType: CommandType.StoredProcedure);
        }

        public async Task RemoveAdmin(decimal userId, decimal removeAdminId, decimal groupId)
        {
            var dp = new DynamicParameters();
            dp.Add("u_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("RemovedAdmin", removeAdminId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("chatID", groupId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("HomeScreen_Package.RemoveAdmin", dp, commandType: CommandType.StoredProcedure);
        }

        public async Task AddMemberToGroup(decimal newUserId, decimal groupId)
        {
            var dp = new DynamicParameters();
            dp.Add("newUser", newUserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("chatID", groupId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("HomeScreen_Package.AddUserToGroup", dp, commandType: CommandType.StoredProcedure);
        }
        public async Task RemoveMemberFromGroup(decimal adminId, decimal userToRemove, decimal groupId)
        {
            var dp = new DynamicParameters();
            dp.Add("u_id", adminId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("UserToRemove", userToRemove, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("chatID", groupId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("HomeScreen_Package.RemoveUserfromGroup", dp, commandType: CommandType.StoredProcedure);
        }
    }
}
