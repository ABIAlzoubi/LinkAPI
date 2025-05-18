using Link.Core.DTO;
using Link.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]
        [Route("CreateUserProfile")]
        public async Task<IActionResult> CreateUserProfile([FromBody] linkUserDto profile) 
        {
            if (profile == null) 
            {
                return BadRequest("Empty Value");
            }
            await _profileService.CreateUserProfile(profile);
            return Ok("created Successfully");
        }

        [HttpGet]
        [Route("GetUserProfile/user_id")]
        public async Task<IActionResult> GetUserProfile(decimal user_id)
        {
            if (user_id <= 0)
            {
                return BadRequest("invaled userId");
            }
            var result = await _profileService.GetUserProfile(user_id);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateUserProfile")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] linkUserDto profile)
        {
            if (profile == null)
            {
                return BadRequest("Empty Value");
            }
            if (profile.USERID <= 0) 
            {
                return BadRequest("invaled userId");
            }
            await _profileService.UpdateUserProfile(profile);
            return Ok("Updated Successfully");
        }
    }
}
