using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Api.Auth.Models;
using Web.Core.Auth.Services;

namespace Web.Api.Auth.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoginController : Controller
    {
        private readonly IAuthentificationService _authService;
        public LoginController(IAuthentificationService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> RequestToken([FromBody] TokenRequest request)
        {
            if (ModelState.IsValid)
            {
                string token = await _authService.Authentificate(request.Email, request.Password);
                if(token == null)
                {
                    return BadRequest(new { message = "Email or password is incorrect" });
                }

                return Ok(token);
            }

            return BadRequest(ModelState);
        }
    }
}
