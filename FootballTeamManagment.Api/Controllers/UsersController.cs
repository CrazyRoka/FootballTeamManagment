using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Services;
using FootballTeamManagment.Api.Models;

namespace FootballTeamManagment.Auth.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody]UserView userView)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(userView);
                var createdUser = await _userService.CreateUserAsync(user, new ApplicationRole[] { ApplicationRole.Common });
                
                if(createdUser == null)
                {
                    return BadRequest(new { message = "Email is already in use" });
                }

                var createdUserView = _mapper.Map<UserView>(createdUser);
                return Ok(createdUserView);
            }

            return BadRequest(ModelState);
        }
    }
}
