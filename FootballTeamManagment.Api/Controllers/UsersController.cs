using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Services;
using FootballTeamManagment.Api.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

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
        public async Task<IActionResult> Create([FromBody]UserView userView)
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

        [HttpPut("password")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePassword([FromBody]ResetPasswordRequest request)
        {
            var email = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {
                bool updated = await _userService.UpdatePasswordAsync(email, request.OldPassword, request.NewPassword);
                if (updated)
                {
                    return Ok();
                }   
                return BadRequest("Invalid password");
            }
            return BadRequest(ModelState);
        }
    }
}
