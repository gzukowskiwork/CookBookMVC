using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Models.Identity;

namespace CookBookMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _autoMapper;
        private readonly ILoggerManager _logger;

        public AccountController(UserManager<ApplicationUser> userManager, IMapper autoMapper, ILoggerManager logger)
        {
            _autoMapper = autoMapper;
            _userManager = userManager;
            _logger = logger;

        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            //TODO send email message if somenoe tries to register or login on existing email
            IdentityResult result = await _userManager.CreateAsync(user, user.Password);
            
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(user);
            }

            await _userManager.AddToRoleAsync(user, "RegisteredUser");

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            ApplicationUser user = await _userManager.FindByEmailAsync(loginModel.Email);

            return await AddClaimsToUserAndRedirect(loginModel, user);

        }

        private async Task<IActionResult> AddClaimsToUserAndRedirect(LoginModel loginModel, ApplicationUser user)
        {
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                ClaimsIdentity identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(identity));

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid user name or password");
                return View();
            }
        }
    }
}
