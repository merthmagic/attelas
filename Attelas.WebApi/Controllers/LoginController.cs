using Attelas.Application.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Attelas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(IAuthenticationService authenticationService) : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
        {
            var result = authenticationService.Authenticate(request);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized(result);
            }
        }
    }
}