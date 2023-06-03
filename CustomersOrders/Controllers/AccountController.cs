using CustomersOrders.Data;
using CustomersOrders.Data.ViewModels;
using CustomersOrders.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;

namespace CustomersOrders.Controllers
{
    public class AccountController : Controller
    {
       // private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDBContext _appDBContext;
        public AccountController(UserManager<ApplicationUser> userManager, AppDBContext appDBContext, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _appDBContext = appDBContext;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Users()
        {
            var users = await _appDBContext.Users.ToListAsync();
            return View(users);
        }


        public IActionResult Login() => View(new LoginVM());
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);
            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

            }
            TempData["Error"] = "Invalid credentails , PLZ try again!";
            return View(loginVM);
        }




        public IActionResult Register() => View(new RegisterVM());




        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }
            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser()
                {
                    FullName = registerVM.FullName,
                    Email = registerVM.EmailAddress,
                    UserName = registerVM.EmailAddress
                };
                var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);
                if (newUserResponse.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in newUserResponse.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }
            }
            return View(registerVM);
        }

    }
}
