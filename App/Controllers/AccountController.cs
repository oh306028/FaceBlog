using App.Models;
using App.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly BlogDbContext _context;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, BlogDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
           _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var newUser = new AppUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.UserName,
                };

               

                var result = await _userManager.CreateAsync(newUser, model.Password);

                if (result.Succeeded)
                {                 
                   

                    var address = new Address
                    {
                        Country = model.Country,
                        City = model.City,
                        Street = model.Street,
                        UserId = newUser.Id
                    };

                    _context.Add(address);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");

                }

                ModelState.AddModelError("", "Register attempt went wrong");

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
                
            }
            ModelState.AddModelError("", "Register attempt went wrong");

            return View(model);
        }



  
        public IActionResult Register()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            ModelState.AddModelError("", "Login attempt went wrong");


            return View(model);
        }



     


    }
}
