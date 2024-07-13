using App.Models;
using App.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


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


        public IActionResult Update()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var currentUser = await _userManager.FindByNameAsync(userName);

               
                if (!string.IsNullOrEmpty(model.Password))
                {
                    var updatedPassword = _userManager.PasswordHasher.HashPassword(currentUser, model.Password);
                    currentUser.PasswordHash = updatedPassword;
                }

                currentUser.UserName = model.UserName ?? currentUser.UserName;
                currentUser.FirstName = model.FirstName ?? currentUser.FirstName;
                currentUser.LastName = model.LastName ?? currentUser.LastName;
                currentUser.Email = model.Email ?? currentUser.Email;
                currentUser.Address.Country = model.Country ?? currentUser.Address.Country;
                currentUser.Address.City = model.City ?? currentUser.Address.City;
                currentUser.Address.Street = model.Street ?? currentUser.Address.Street;
                currentUser.PhoneNumber = model.PhoneNumber ?? currentUser.PhoneNumber;


                var result = await _userManager.UpdateAsync(currentUser);

                if (result.Succeeded)
                {
                    return RedirectToAction("Update", "Account");
                }

                ModelState.AddModelError("", "Update attempt went wrong");

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }


                return View(model);

            }

          
            ModelState.AddModelError("", "Update attempt went wrong");
            return View(model);

        }




        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByEmailAsync(model.Email);

                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            ModelState.AddModelError("", "Login attempt went wrong");


            return View(model);
        }




        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
            
        }


     


    }
}
