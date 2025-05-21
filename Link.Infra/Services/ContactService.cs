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
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService (IContactRepository contactRepository)
        {  _contactRepository = contactRepository; }


        public async Task AddNewContact(decimal u_id, decimal Contact_id)
        {
             await _contactRepository.AddNewContact(u_id, Contact_id);
        }

        public async Task<List<ContactsDto>> GetAllContacts(decimal u_id)
        {
            return await _contactRepository.GetAllContacts(u_id);
        }

        public async Task DeleteContact(decimal u_id, decimal Contact_id)
        {
            await _contactRepository.DeleteContact(u_id, Contact_id);
        }
    }
}
