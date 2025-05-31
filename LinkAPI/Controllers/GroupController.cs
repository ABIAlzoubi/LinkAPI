using Link.Core.DTO;
using Link.Core.Services;
using Link.Core.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService) 
        {
            _groupService = groupService;
        }


        [HttpPost]
        [Route("createGroup/{userId}/{groupName}/{groupMembersId}")]
        public async Task<IActionResult> CreateGroup(decimal userId, string groupName, string groupMembersId)
        {
            if(userId <= 0)
                return BadRequest("invalid user Name");
            if (CheckStringEmpty.IsEmptyOrPlaceholder(groupName) || CheckStringEmpty.IsEmptyOrPlaceholder(groupMembersId))
                return BadRequest("invalid groupName or group Members Id's");
            await _groupService.CreateGroup(userId, groupName, groupMembersId);
            return Ok();
        }

        [HttpPut]
        [Route("ChangeGroupName/{groupId}/{newName}")]
        public async Task<IActionResult> ChangeGroupName(decimal groupId, string newName) 
        {
            if (groupId <= 0)
                return BadRequest("invalid groupId");
            if (CheckStringEmpty.IsEmptyOrPlaceholder(newName))
                return BadRequest("invalid groupName");
            await _groupService.ChangeGroupName(groupId, newName);
            return Ok();
        }

        [HttpGet]
        [Route("GetGroupMembers/{groupId}")]
        public async Task<IActionResult> getGroupMembers(decimal groupId)
        {
            if (groupId <= 0)
                return BadRequest("invalid groupId");
            var result = await _groupService.getGroupMembers(groupId);
            return Ok(result);
        }

        [HttpPut]
        [Route("AddAdmin/{userId}/{newAdminId}/{groupId}")]
        public async Task<IActionResult>AddAdmin(decimal userId, decimal newAdminId, decimal groupId)
        {
            if (groupId <= 0 || newAdminId <=0 || userId<=0)
                return BadRequest("invalid values");
            await _groupService.AddAdmin(userId, newAdminId, groupId);
            return Ok();
        }

        [HttpPut]
        [Route("RemoveAdmin/{userId}/{removeAdminId}/{groupId}")]
        public async Task<IActionResult> RemoveAdmin(decimal userId, decimal removeAdminId, decimal groupId)
        {
            if (groupId <= 0 || removeAdminId <= 0 || userId <= 0)
                return BadRequest("invalid values");
            await _groupService.RemoveAdmin(userId, removeAdminId, groupId);
            return Ok();
        }

        [HttpPost]
        [Route("AddMemberToGroup/{newUserId}/{groupId}")]
        public async Task<IActionResult> AddMemberToGroup(decimal newUserId, decimal groupId)
        {
            if (newUserId <= 0 || groupId <= 0)
                return BadRequest("invalid user id or group id");
            await _groupService.AddMemberToGroup(newUserId, groupId);
            return Ok();
        }
        
        [HttpDelete]
        [Route("RemoveMemberFromGroup/{adminId}/{userToRemove}/{groupId}")]
        public async Task<IActionResult> RemoveMemberFromGroup(decimal adminId, decimal userToRemove, decimal groupId)
        {
            if (adminId <= 0 || userToRemove <= 0 || groupId <= 0)
                return BadRequest("invalid user id or userToRemove or group id");
            await _groupService.RemoveMemberFromGroup(adminId, userToRemove, groupId);
            return Ok();
        }
    }
}
