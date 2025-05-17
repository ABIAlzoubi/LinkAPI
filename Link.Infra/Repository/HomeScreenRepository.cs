using Dapper;
using Link.Core.Common;
using Link.Core.DTO;
using Link.Core.Repository;
using System.Data;

namespace Link.Infra.Repository
{
    public class HomeScreenRepository: IHomeScreenRepository
    {
        private readonly IDbContext _dBContext;

        public HomeScreenRepository (IDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<ActiveUsersDto>> GetActiveUsers(decimal userID) 
        { 
            var dp = new DynamicParameters();
            dp.Add("u_id", userID, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = await _dBContext.Connection.QueryAsync<ActiveUsersDto>("HomeScreen_Package.GetAllActiveUsers", dp, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<linkUserDto> searchForUser(String userName)
        {
            var dp = new DynamicParameters();
            dp.Add("u_name", userName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = await _dBContext.Connection.QueryAsync<linkUserDto>("HomeScreen_Package.GetuserByUserName", dp, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public async Task<List<ChatDto>> GetAllChatsByuserID(decimal userID)
        {
            var dp = new DynamicParameters();
            dp.Add("u_id", userID, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = await _dBContext.Connection.QueryAsync<ChatDto>("HomeScreen_Package.GetAllChatsByuserID", dp, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



        public async Task<List<UnreadedMessagesCountDto>> GetAllUnreadMessagesCount(decimal userID)
        {
            var dp = new DynamicParameters();
            dp.Add("u_id", userID, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = await _dBContext.Connection.QueryAsync<UnreadedMessagesCountDto>("HomeScreen_Package.GetNumberOfUnreadedMessagesInChat", dp, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
