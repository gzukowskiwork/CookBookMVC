using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using EmailLib;
using EmailService;
using LoggerService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Models.Identity;

namespace CookBookMVC.Controllers
{
    //TODO  add logging where possible
    //TODO check for exception handling
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _autoMapper;
        private readonly ILoggerManager _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ISendEmail _sendEmail;

        public AccountController(
              UserManager<ApplicationUser> userManager
            , IMapper autoMapper
            , ILoggerManager logger
            , SignInManager<ApplicationUser> signInManager
            , ISendEmail sendEmail)
        {
            _autoMapper = autoMapper;
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
            _sendEmail = sendEmail;
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
            
            var existingUser = await _userManager.FindByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return await SendSecurityViolationMessageAndReturnView(existingUser);
            }

            IdentityResult result = await _userManager.CreateAsync(user, user.Password);

            if (!result.Succeeded)
            {
                return AddErrorsAndReturnToRegistrationView(user, result);
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmEmailLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, user.Email }, Request.Scheme);

            var message = new Message(new string[] { user.Email }, "Confirmation email link", confirmEmailLink);
            await _sendEmail.SendEmailAsync(message);

            await _userManager.AddToRoleAsync(user, "RegisteredUser");

            return RedirectToAction(nameof(SuccessRegistration));
        }

        private async Task<IActionResult> SendSecurityViolationMessageAndReturnView(ApplicationUser existingUser)
        {
            var securityMessage = new Message(
                                new string[] { existingUser.Email }
                                , "Possible security violation"
                                , "Someone tried to register with Your eamil in Cook Book Application. If it was You ignore this message"
                                );
            await _sendEmail.SendEmailAsync(securityMessage);
            _logger.LogInfo("Someone tried to login on "+ existingUser.Email + " existing email");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {

            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            ViewBag.HasConfirmedEmail = result.Succeeded;

            return View(result.Succeeded?nameof(Login): "Error");
        }

        [HttpGet]
        public IActionResult SuccessRegistration()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpGet]
        public IActionResult Error()
        {
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

            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, true);
           
            return CheckLoginSuccsessAndRedirect(returnUrl, result, user.Email);

            
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        private IActionResult CheckLoginSuccsessAndRedirect(string returnUrl, Microsoft.AspNetCore.Identity.SignInResult result, string emial)
        {
            if (result.Succeeded)
            {
                return SignInAndRedirectToAction(returnUrl);
            }
            if (result.IsLockedOut)
            {
                var forgotPassLink = Url.Action(nameof(ForgotPassword), "Account", new { }, Request.Scheme);
                var content = string.Format("Your account is locked out, to reset your password, please click this link: {0}", forgotPassLink);

                var message = new Message(new string[] { emial }, "Locked out account information", content);
                _sendEmail.SendEmailAsync(message);
                ModelState.AddModelError("", "This account is locked out");
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Invalid login atempt");
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


        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordModel);
            }

            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
            {
                return RedirectToAction(nameof(ForgotPasswordBadEmail));
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action(nameof(ResetPassword), "Account", new
            {
                token,
                email = user.Email,
            }, Request.Scheme);

            var message = new Message(new string[] { user.Email.ToString() }, "Reset password token", callback);
            await _sendEmail.SendEmailAsync(message);

            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }

        [HttpGet]
        public IActionResult ForgotPasswordBadEmail()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetModel resetModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetModel);
            }

            var user = await _userManager.FindByEmailAsync(resetModel.Email);

            if(user == null)
            {
                RedirectToAction(nameof(ForgotPasswordBadEmail));
            }

            var resetPasswordResult = await _userManager.ResetPasswordAsync(user, resetModel.Token, resetModel.Password);

            if (!resetPasswordResult.Succeeded)
            {

                return AddErrorsAndReturnToRegistrationView(user, resetPasswordResult);
                //foreach(var errors in resetPasswordResult.Errors)
                //{
                //    ModelState.TryAddModelError(errors.Code, errors.Description);
                //}

                //return View();
            }

            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        #region ExternalAuth
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalAuth(string provider, string returnUrl = null)
        {
            string redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            AuthenticationProperties properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        public async Task<IActionResult> ExternalLoginCallback(string returnUrl= null)
        {
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            if(info == null)
            {
                return RedirectToAction(nameof(Login));
            }
            var signInResult = 
                await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                return SignInAndRedirectToAction(returnUrl);
            }
            if (signInResult.IsLockedOut)
            {
                return RedirectToAction(nameof(ForgotPassword));
            }
            else
            {
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["Provider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLogin", new ExternalLoginModel { Email = email });
            }
        }

        public async Task<IActionResult> ExternalLoginConfrmation(ExternalLoginModel model, string returnUrl= null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();

            if(info == null)
            {
                return View(nameof(Error));
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            IdentityResult result;
            if (user!=null)
            {
                result = await _userManager.AddLoginAsync(user, info);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: true);
                    return SignInAndRedirectToAction(returnUrl);
                }
            }
            else
            {
                result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: true);
                    return SignInAndRedirectToAction(returnUrl);
                }
            }

            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return View(nameof(ExternalAuth), model);
        }
#endregion

        [HttpGet]
        public IActionResult Details()
        {
            
            return View();
        }


    }
}
