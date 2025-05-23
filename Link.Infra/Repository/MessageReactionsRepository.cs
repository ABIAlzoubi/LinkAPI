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
    public class MessageReactionsRepository : IMessageReactionsRepository
    {
        private readonly IDbContext _dpContext;
        public MessageReactionsRepository(IDbContext dpContext)
        {
            _dpContext = dpContext;
        }

        public async Task AddReaction(decimal m_id, decimal u_id, string type)
        {
            var dp = new DynamicParameters();
            dp.Add("m_id", m_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("u_id", u_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("reactionType", type, dbType: DbType.String, direction: ParameterDirection.Input);
            await _dpContext.Connection.ExecuteAsync("HomeScreen_Package.AddReaction", dp, commandType: CommandType.StoredProcedure);
        }
        public async Task EditReaction(decimal m_id, decimal u_id, string type)
        {
            var dp = new DynamicParameters();
            dp.Add("m_id", m_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("u_id", u_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("reactionType", type, dbType: DbType.String, direction: ParameterDirection.Input);
            await _dpContext.Connection.ExecuteAsync("HomeScreen_Package.EditRaction", dp, commandType: CommandType.StoredProcedure);
        }
        public async Task RemoveReaction(decimal m_id, decimal u_id)
        {
            var dp = new DynamicParameters();
            dp.Add("m_id", m_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("u_id", u_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dpContext.Connection.ExecuteAsync("HomeScreen_Package.DeleteReaction", dp, commandType: CommandType.StoredProcedure);
        }
        public async Task<List<ReactionsDto>> GetMessageReactions(decimal m_id)
        {
            var dp = new DynamicParameters();
            dp.Add("m_id", m_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dpContext.Connection.QueryAsync<ReactionsDto>("HomeScreen_Package.GetSingleMessageReaction", dp, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
