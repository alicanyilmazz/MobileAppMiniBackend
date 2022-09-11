using CoreBackend.Auth.Models;
using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CoreBackend.Auth.Services
{
    public class IdentityResourcesOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourcesOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser = await _userManager.FindByEmailAsync(context.UserName);
            if (existUser == null)
                return;

            var passwordCheck = await _userManager.CheckPasswordAsync(existUser,context.Password);

            if (passwordCheck == false)
                return;

            context.Result = new GrantValidationResult(existUser.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
        }
    }
}
