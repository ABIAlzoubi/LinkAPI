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
    public class MessageReactionsService : IMessageReactionsService
    {
        private readonly IMessageReactionsRepository _messageReactionsRepository;
        public MessageReactionsService(IMessageReactionsRepository messageReactionsRepository)
        {
            _messageReactionsRepository = messageReactionsRepository;
        }

        public async Task AddReaction(decimal m_id, decimal u_id, string type)
        {
            await _messageReactionsRepository.AddReaction(m_id, u_id, type);
        }
        public async Task EditReaction(decimal m_id, decimal u_id, string type) 
        {
            await _messageReactionsRepository.EditReaction(m_id, u_id, type);
        }
        public async Task RemoveReaction(decimal m_id, decimal u_id)
        { 
            await _messageReactionsRepository.RemoveReaction(m_id, u_id);
        }
        public async Task<List<ReactionsDto>> GetMessageReactions(decimal m_id)
        { 
            return await _messageReactionsRepository.GetMessageReactions(m_id);
        }
    }
}
