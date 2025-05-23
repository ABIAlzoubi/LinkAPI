using Link.Core.DTO;
using Link.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesReactionsController : ControllerBase
    {
        private readonly IMessageReactionsService _messageReactionsService;
        public MessagesReactionsController (IMessageReactionsService messageReactionsService)
        {
            _messageReactionsService = messageReactionsService;
        }

        [HttpPost]
        [Route("AddReaction/{m_id}/{u_id}/{type}")]
        public async Task<IActionResult> AddReaction(decimal m_id, decimal u_id, string type)
        {
            if (m_id <= 0 || u_id <=0 || type == "" || type ==null) 
            {
                return BadRequest("Invalid Values");
            }
            await _messageReactionsService.AddReaction(m_id, u_id, type);
            return Ok();
        }


        [HttpPut]
        [Route("EditReaction/{m_id}/{u_id}/{type}")]
        public async Task<IActionResult> EditReaction(decimal m_id, decimal u_id, string type)
        {
            if (m_id <= 0 || u_id <= 0 || type == "" || type == null)
            {
                return BadRequest("Invalid Values");
            }
            await _messageReactionsService.EditReaction(m_id, u_id, type);
            return Ok();
        }

        [HttpDelete]
        [Route("RemoveReaction/{m_id}/{u_id}")]
        public async Task<IActionResult> RemoveReaction(decimal m_id, decimal u_id) 
        {
            if (m_id <= 0 || u_id <= 0)
            {
                return BadRequest("Invalid Values");
            }
            await _messageReactionsService.RemoveReaction(m_id, u_id);
            return Ok();
        }

        [HttpGet]
        [Route("GetMessageReactions/{m_id}")]
        public async Task<IActionResult> GetMessageReactions(decimal m_id)
        {
            if (m_id <= 0)
            {
                return BadRequest("Invalid message id");
            }
            var result = await _messageReactionsService.GetMessageReactions(m_id);
            return Ok(result);

        }
    }
}
