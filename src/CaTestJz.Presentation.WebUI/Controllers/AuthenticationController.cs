using CaTestJz.Application.Services.Authentication;
using CaTestJz.Presentation.WebUI.Model.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CaTestJz.Presentation.WebUI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            AuthenticationResult authResult = await _authenticationService.Login(request.Email, request.Password);
            AuthenticationResponse response = MapAuthResult(authResult);

            if (authResult.AllowLogin)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.AccessToken,
                authResult.RefreshToken
                );
        }


    }
}
