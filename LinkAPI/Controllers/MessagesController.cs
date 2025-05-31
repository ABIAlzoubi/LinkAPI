using Link.Core.DTO;
using Link.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessagesService _messagesService;
        public MessagesController(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        [HttpPost]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDto message) 
        {
            if (message == null)
            {
                return BadRequest("message not sent");
            }
            if (message.sender_id <= 0 || message.chat_id <=0)
            {
                return BadRequest("invalid user_id or chat id ");
            }
            if (message.reply_to_message_id <= 0)
            {
                message.reply_to_message_id = null;
            }
            await _messagesService.SendMessage(message);
            return Ok("message sent Successfully");
        }

        [HttpPut]
        [Route("EditMessage/{u_id}/{m_id}/{m_content}")]
        public async Task<IActionResult> EditMessage(decimal u_id,decimal m_id, string m_content)
        {

            if (m_id <= 0 || m_content == null || m_content == "")
            {
                return BadRequest("invalid user_id or content ");
            }
            var sender_id = await _messagesService.SenderID(m_id);
            if (u_id != sender_id) 
            {
                return BadRequest("user_id not allowed to update this message");
            }
            await _messagesService.EditMessage(m_id, m_content);
            return Ok("message Edited");
        }

        [HttpDelete]
        [Route("DeleteMessage/{m_id}/{u_id}")]
        public async Task<IActionResult> DeleteMessage(decimal m_id, decimal u_id)
        {
            if (m_id <= 0 || u_id <= 0)
            {
                return BadRequest("invalid user_id or message id ");
            }
            await _messagesService.DeleteMessage(m_id, u_id);
            return Ok("Message has been deleted");

        }

        [HttpGet]
        [Route("GetMessageInfo/{m_id}")]
        public async Task<IActionResult> GetMessageInfo(decimal m_id)
        {
            if (m_id <= 0)
            {
                return BadRequest("invalid message id ");
            }
            var result = await _messagesService.GetMessageInfo(m_id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetChatMessages/{chat_id}")]
        public async Task<IActionResult> GetChatMessages(decimal chat_id) 
        {
            if (chat_id <= 0)
            {
                return BadRequest("invalid chat id");
            }
            var result = await _messagesService.GetChatMessages(chat_id);
            return Ok(result);
        }

        [HttpPut]
        [Route("MakeMessageSeen/{m_id}/{user_id}")]
        public async Task<IActionResult> MakeMessageSeen(decimal m_id,decimal user_id) 
        {
            if (m_id <= 0 || user_id <= 0)
            {
                return BadRequest("invalid message id or user id");
            }
            decimal senderID = await _messagesService.SenderID(m_id);
            if (user_id == senderID)
            {
                return BadRequest("user is the sender");
            }
            return Ok();
        }

        [HttpPut]
        [Route("MakeMessageUnSeen/{m_id}/{user_id}")]
        public async Task<IActionResult> MakeMessageUnSeen(decimal m_id, decimal user_id)
        {
            if (m_id <= 0 || user_id <= 0)
            {
                return BadRequest("invalid message id or user id");
            }
            decimal senderID = await _messagesService.SenderID(m_id);
            if (user_id == senderID)
            {
                return BadRequest("user is the sender");
            }
            return Ok();
        }
    }
}
