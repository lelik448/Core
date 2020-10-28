using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Core.ViewModels;
using Core_1.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginViewModel login)
        {

            if (!ModelState.IsValid) { return View(login); }

            var loginResult = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false);

            if (!loginResult.Succeeded)
            {
                ModelState.AddModelError("", "Все пропало");
                return View(login);
            }

            if (Url.IsLocalUrl(login.ReturnUrl))
            {
                return Redirect(login.ReturnUrl);
            }

            return RedirectToAction ("Index","Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(RegisterUserViewModel register)
        {
            if (!ModelState.IsValid) { return View(register); }

            var user = new User { UserName = register.UserName, Email = register.Email };

            var createResult = await _userManager.CreateAsync(user, register.Password);

            if (!createResult.Succeeded)
            {
                foreach (var identityError in createResult.Errors)//выводим ошибки
                {
                    ModelState.AddModelError("", identityError.Description);
                    return View(register);
                }
            }

            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
