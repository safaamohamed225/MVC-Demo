using Demo.Models;
using Demo.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager <ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel userVM)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser userApp = await userManager.FindByNameAsync(userVM.UserName);
                if(userApp !=null)
                {
                    bool found=await userManager.CheckPasswordAsync(userApp, userVM.Password);
                    if(found==true)
                    {
                        await signInManager.SignInAsync(userApp, userVM.RememberMe);
                        return RedirectToAction("Index", "Employee");
                    }
                }
                ModelState.AddModelError("", "UserName or Password Wrong");

            }

            return View(userVM); 
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.UserName = newUserVM.UserName;
                applicationUser.Address = newUserVM.Address;
                applicationUser.Email = newUserVM.Email;
                applicationUser.PasswordHash = newUserVM.Password;
                IdentityResult result=await userManager.CreateAsync(applicationUser,newUserVM.Password);

                if (result.Succeeded)
                {

                    //await userManager.AddToRoleAsync(applicationUser, "Student");
                    // List<Claim> claims = new List<Claim>();
                    // claims.Add(new Claim("Red", "Blue"));
                    //await signInManager.SignInWithClaimsAsync(applicationUser, false, claims);
                    await signInManager.SignInAsync(applicationUser, false);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    foreach(var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("password", errorItem.Description);
                    }

                }
            }
            return View(newUserVM);
        }

        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        [Authorize (Roles ="Admin")]
        public async Task<IActionResult> AddAdmin(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.UserName = newUserVM.UserName;
                applicationUser.Address = newUserVM.Address;
                applicationUser.Email = newUserVM.Email;
                applicationUser.PasswordHash = newUserVM.Password;
                IdentityResult result = await userManager.CreateAsync(applicationUser, newUserVM.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(applicationUser, "Admin");
                    await signInManager.SignInAsync(applicationUser, false);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("password", errorItem.Description);
                    }

                }
            }
            return View(newUserVM);
        }
    }
}
