using CoreBackend.Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace CoreBackend.Auth.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Test()
        {
            return Ok("test ok");
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            var user = new ApplicationUser(); // Veritabanındaki User tablomuza karsılık gelen entity miz budur.
            user.UserName = signUpViewModel.UserName;
            user.Email = signUpViewModel.Email;
            user.Country = signUpViewModel.Country;
            var result = await _userManager.CreateAsync(user, signUpViewModel.Password);

            if (!result.Succeeded)
            {
                // TODO : ERRORS
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null)
                return BadRequest();

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            if (user == null)
                return BadRequest();

            var userDto = new ApplicationUser { UserName = user.UserName, Email = user.Email, Country = user.Country };

            return Ok(userDto); 
        }
    }
}
