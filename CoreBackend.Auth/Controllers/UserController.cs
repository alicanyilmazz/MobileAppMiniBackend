using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static IdentityServer4.IdentityServerConstants;

namespace CoreBackend.Auth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Authorize(LocalApi.PolicyName)]
        public IActionResult Test()
        {
            return Ok("test ok");
        }

        public IActionResult SignUp()
        {
            return Ok("test ok");
        }
    }
}
