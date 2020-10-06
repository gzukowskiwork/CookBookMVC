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
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager
            , IMapper autoMapper
            , ILoggerManager logger
            , SignInManager<ApplicationUser> signInManager)
        {
            _autoMapper = autoMapper;
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;

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
                return AddErrorsAndReturnToRegistrationView(user, result);
            }

            await _userManager.AddToRoleAsync(user, "RegisteredUser");

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            ApplicationUser user = await _userManager.FindByEmailAsync(loginModel.Email);

            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, false);
            
            return CheckLoginSuccsessAndRedirect(returnUrl, result);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }



        private IActionResult CheckLoginSuccsessAndRedirect(string returnUrl, Microsoft.AspNetCore.Identity.SignInResult result)
        {
            if (result.Succeeded)
            {
                
                return SignInAndRedirectToAction(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid user name or password");
                return View();
            }
        }


        private IActionResult AddErrorsAndReturnToRegistrationView(ApplicationUser user, IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return View(user);
        }

        private IActionResult SignInAndRedirectToAction(string returnUrl)
        {

            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
