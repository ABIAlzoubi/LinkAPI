using Link.Core.DTO;
using Link.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpPost]
        [Route("AddNewContact/{u_id}/{Contact_id}")]
        public async Task<IActionResult> AddNewContact(decimal u_id, decimal Contact_id)
        {
            if (u_id <= 0 || Contact_id <= 0)
            {
                return BadRequest("invalid User id Or Contnat Id");
            }

            if (Contact_id == u_id)
            {
                return BadRequest("User id and Contnat Id are the same");
            }
            await _contactService.AddNewContact(u_id, Contact_id);
            return Ok("Contact Added Successfully");

        }



        [HttpGet]
        [Route("GetAllContacts/{u_id}")]
        public async Task<IActionResult> GetAllContacts(decimal u_id)
        {
            if (u_id <= 0)
            {
                return BadRequest("invalid User id ");
            }
            var result = await _contactService.GetAllContacts(u_id);
            return Ok(result);
        }


        [HttpDelete]
        [Route("DeleteContact/{u_id}/{Contact_id}")]
        public async Task<IActionResult> DeleteContact( decimal u_id, decimal Contact_id)
        {
            if (u_id <= 0 || Contact_id <= 0)
            {
                return BadRequest("invalid User id Or Contnat Id");
            }
            if (Contact_id == u_id)
            {
                return BadRequest("User id and Contnat Id are the same");
            }
            await _contactService.DeleteContact(u_id, Contact_id);
            return Ok("Contact has been deleted");

        }
    }
}
