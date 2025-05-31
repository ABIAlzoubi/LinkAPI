using Link.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Core.Services
{
    public interface IMessagesService
    {
        public Task<decimal> SenderID(decimal m_id);
        public Task SendMessage(SendMessageDto message);
        public Task EditMessage(decimal m_id, string m_content);
        public Task DeleteMessage(decimal m_id, decimal u_id);
        public Task<MessageDto> GetMessageInfo(decimal m_id);
        public Task<List<MessageDto>> GetChatMessages(decimal chat_id);
        public Task MakeMessageSeen(decimal m_id);
        public Task MakeMessageUnSeen(decimal m_id);
    }
}
