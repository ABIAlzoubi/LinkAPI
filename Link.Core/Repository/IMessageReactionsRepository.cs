using Link.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Core.Repository
{
    public interface IMessageReactionsRepository
    {
        public Task AddReaction(decimal m_id, decimal u_id, string type);
        public Task EditReaction(decimal m_id, decimal u_id, string type);
        public Task RemoveReaction(decimal m_id, decimal u_id);
        public Task<List<ReactionsDto>> GetMessageReactions(decimal m_id);
    }
}
