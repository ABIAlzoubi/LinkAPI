using Link.Core.DTO;
using Link.Core.Services;
using Link.Core.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace LinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;
        public ProfileController(IProfileService profileService, IConfiguration config, IWebHostEnvironment env)
        {
            _profileService = profileService;
            _config = config;
            _env = env;
        }

        [HttpPost]
        [Route("CreateUserProfile")]
        public async Task<IActionResult> CreateUserProfile([FromBody] linkUserDto profile) 
        {
            if (profile == null) 
            {
                return BadRequest("Empty Value");
            }

            var hashedPassword = HashingPasswordUtil.HashPassword(profile.HASHEDPASSWORD!);
            profile.HASHEDPASSWORD = hashedPassword;

            await _profileService.CreateUserProfile(profile);
            return Ok("created Successfully");
        }

        [HttpGet]
        [Route("GetUserProfile/{user_id}")]
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



        [HttpPost("UploadProfileImage")]
        public async Task<IActionResult> UploadProfileImage(IFormFile file, [FromForm] int userId)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            var uploadsPath = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsPath))
                Directory.CreateDirectory(uploadsPath);

            var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var fullPath = Path.Combine(uploadsPath, uniqueFileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Construct public URL
            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var fileUrl = $"{baseUrl}/uploads/{uniqueFileName}";


            return Ok(new { imageUrl = fileUrl });
        }

    }
}
