using E.Core.IdentityModule.Requests;
using E.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace E.Core.IdentityModule.Services
{
    public interface IIdentityService
    {
        Task<IdentityResult> RegisterAsync(RegisterRequest request);
        Task<SignInResult> LoginAsync(LoginRequest request);
        Task Logout();
    }
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> LoginAsync(LoginRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterAsync(RegisterRequest request)
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            return result;
        }
    }
}
