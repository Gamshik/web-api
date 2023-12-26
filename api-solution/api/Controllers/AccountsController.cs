using Entites.DataTransferObject.UserDtos;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace cinemaApi.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class AccountsController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountsController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegiserUserAsync(UserForRegistrationDto userForRegistrationDto)
        {
            var result = await _authenticationService.RegisterUserAsync(userForRegistrationDto);

            return result.Succeeded ? StatusCode(201) : BadRequest(result);
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateUserAsync(UserForLoginDto userForLoginDto)
        {
            var token = await _authenticationService.AuthenticateUserAsync(userForLoginDto);

            return token == null ? Unauthorized("Invalid authentication!") : Ok(token);
        }
    }
}