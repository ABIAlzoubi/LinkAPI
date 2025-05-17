using Link.Core.DTO;
using Link.Core.Repository;
using Link.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeScreenController : ControllerBase
    {
        private readonly IHomeScreenService _homeScreenService;
        public HomeScreenController(IHomeScreenService homeScreenService)
        {
            _homeScreenService = homeScreenService;
        }


        [HttpGet]
        [Route("GetActiveUsers/{userID}")]
        public async Task<IActionResult> GetActiveUsers(decimal userID) 
        {
            if (userID < 0) 
            {
                return BadRequest("Invalid Userid");
            }
            var result = await _homeScreenService.GetActiveUsers(userID);
            return Ok(result);
        }



        [HttpGet]
        [Route("searchForUser/{userName}")]
        public async Task<IActionResult> searchForUser(String userName) 
        {
            if (userName.IsNullOrEmpty())
            {
                return BadRequest("Invalid Userid");
            }
            var result = await _homeScreenService.searchForUser(userName);
            return Ok(result);
        }



        [HttpGet]
        [Route("GetAllChatsByuserID/{userID}")]
        public async Task<IActionResult> GetAllChatsByuserID(decimal userID) 
        {
            if (userID < 0)
            {
                return BadRequest("Invalid Userid");
            }
            var result = await _homeScreenService.GetActiveUsers(userID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllUnreadMessagesCount/{userID}")]
        public async Task<IActionResult> GetAllUnreadMessagesCount(decimal userID) 
        {
            if (userID < 0)
            {
                return BadRequest("Invalid Userid");
            }
            var result = await _homeScreenService.GetActiveUsers(userID);
            return Ok(result);
        }

    }
}
