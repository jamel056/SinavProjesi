using E.Core.IdentityModule.Requests;
using E.Core.IdentityModule.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamCreator.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityService _identityService;

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (ModelState.IsValid)
            {

                var result = await _identityService.RegisterAsync(request);

                if (result.Succeeded)
                {

                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(request);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _identityService.LoginAsync(request);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(request);
        }

        public async Task<IActionResult> Logout()
        {
            await _identityService.Logout();

            return RedirectToAction("Login");
        }
    }
}
