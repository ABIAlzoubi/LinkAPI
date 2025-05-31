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
    public class MessagesRepository : IMessagesRepository
    {
        private readonly IDbContext _dbContext;
        public MessagesRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<decimal> SenderID(decimal m_id) 
        {
            var dp = new DynamicParameters();
            dp.Add("m_id", m_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<decimal>("HomeScreen_Package.GetMessageSender_id", dp, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public async Task SendMessage(SendMessageDto message)
        {
            var dp = new DynamicParameters();
            dp.Add("m_content",message.content , dbType:DbType.String , direction:ParameterDirection.Input);
            dp.Add("ReplayTo", message.reply_to_message_id , dbType:DbType.String , direction:ParameterDirection.Input);
            dp.Add("u_id", message.sender_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("chatID", message.chat_id , dbType:DbType.Int32, direction:ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("HomeScreen_Package.SendMessage", dp, commandType: CommandType.StoredProcedure);
        }

        public async Task EditMessage(decimal m_id, string m_content) 
        {
            var dp = new DynamicParameters();
            dp.Add("m_id", m_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("m_content", m_content, dbType: DbType.String, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("HomeScreen_Package.EditMessage", dp, commandType: CommandType.StoredProcedure);
        }



        public async Task DeleteMessage(decimal m_id, decimal u_id)
        {
            var dp = new DynamicParameters();
            dp.Add("m_id", m_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dp.Add("u_id", u_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("HomeScreen_Package.Deletemessage", dp, commandType: CommandType.StoredProcedure);
        }

        public async Task<MessageDto> GetMessageInfo(decimal m_id) 
        {
            var dp = new DynamicParameters();
            dp.Add("m_id", m_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<MessageDto>("HomeScreen_Package.GetMessageInfo", dp, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault()!;
        }

        public async Task<List<MessageDto>> GetChatMessages(decimal chat_id)
        {
            var dp = new DynamicParameters();
            dp.Add("c_id", chat_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var messages = await _dbContext.Connection.QueryAsync<MessageDto>("HomeScreen_Package.GetMessages", dp, commandType: CommandType.StoredProcedure);
            var messageList = messages.ToList();

            var reactions = await _dbContext.Connection.QueryAsync<ReactionsDto>("HomeScreen_Package.GetMessagesReactions", dp, commandType: CommandType.StoredProcedure);
            var reactionList = reactions.ToList();


            var reactionsByMessage = reactionList.GroupBy(r => r.message_id).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var message in messageList)
            {
                reactionsByMessage.TryGetValue(message.message_id, out var messageReactions);
                message.reactions = messageReactions ?? new List<ReactionsDto>();
            }

            return messageList;
        }


        public async Task MakeMessageSeen(decimal m_id) 
        {
            var dp = new DynamicParameters();
            dp.Add("m_id", m_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("HomeScreen_Package.MessageSeen", dp, commandType: CommandType.StoredProcedure);
        }
        public async Task MakeMessageUnSeen(decimal m_id)
        {
            var dp = new DynamicParameters();
            dp.Add("m_id", m_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("HomeScreen_Package.MessageUnSeen", dp, commandType: CommandType.StoredProcedure);
        }
    }
}
