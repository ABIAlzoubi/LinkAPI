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
    public class MessagesService : IMessagesService
    {
        private readonly IMessagesRepository _messagesRepository;
        public MessagesService(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }


        public async Task<decimal> SenderID(decimal m_id) 
        {
            return await _messagesRepository.SenderID(m_id);
        }
        public async Task SendMessage(SendMessageDto message)
        {
            await _messagesRepository.SendMessage(message);
        }

        public async Task EditMessage(decimal m_id, string m_content)
        {
            await _messagesRepository.EditMessage(m_id, m_content);
        }

        public async Task DeleteMessage(decimal m_id, decimal u_id)
        {
            await _messagesRepository.DeleteMessage(m_id, u_id);
        }

        public async Task<MessageDto> GetMessageInfo(decimal m_id)
        {
            return await _messagesRepository.GetMessageInfo(m_id);
        }

        public async Task<List<MessageDto>> GetChatMessages(decimal chat_id)
        { 
            return await _messagesRepository.GetChatMessages(chat_id);
        }
    }
}
