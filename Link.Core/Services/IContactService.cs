using Link.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link.Core.Services
{
    public interface IContactService
    {
        public Task AddNewContact(decimal u_id, decimal Contact_id);
        public Task<List<ContactsDto>> GetAllContacts(decimal u_id);
        public Task DeleteContact(decimal u_id, decimal Contact_id);
    }
}
