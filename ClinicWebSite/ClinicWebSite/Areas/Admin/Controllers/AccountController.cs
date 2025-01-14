using ClinicWebSite.Areas.ViewModels.Account;
using ClinicWebSite.Data;
using ClinicWebSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicWebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signinManager)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signinManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            AppUser user = new AppUser() 
            { 
            Name = registerVM.Name,
            Surname = registerVM.Surname,
            Email = registerVM.Email,
            UserName = registerVM.Username
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);

            if(!result.Succeeded)
            {
                foreach  (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }

            await _signinManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();

            return RedirectToAction(nameof(Controllers.HomeController.Index));
        }
    }
}
