using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.ViewModel;
using System.Security.Claims;

namespace Project.Controllers
{
    public class AcountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AcountController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;

        }
        //Add Admin
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegisterViewModel newuser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser usermodel = new ApplicationUser();
                usermodel.UserName = newuser.UserName;
                usermodel.PasswordHash = newuser.Password;
                usermodel.Address = newuser.Address;

                IdentityResult result = await userManager.CreateAsync(usermodel, newuser.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(usermodel, "Admin");
                    //create cookie
                    await signInManager.SignInAsync(usermodel, isPersistent: false);

                    return RedirectToAction("Index", "Dept");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(newuser);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userVm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser usermodel = await userManager.FindByNameAsync(userVm.UserName);
                if (usermodel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(usermodel, userVm.Password);
                    if (found)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("Address",usermodel.Address));
                        // await signInManager.SignInAsync(usermodel, userVm.RemeberMe);
                        await signInManager.SignInWithClaimsAsync(usermodel,
                            userVm.RemeberMe, claims);

                        return RedirectToAction("Index", "Dept");
                    }
                }
                ModelState.AddModelError("", "UserName and Password is Wrong");
            }

            return View(userVm);
        }







        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel newuser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser usermodel = new ApplicationUser();
                usermodel.UserName = newuser.UserName;
                usermodel.PasswordHash = newuser.Password;
                usermodel.Address = newuser.Address;

                IdentityResult result = await userManager.CreateAsync(usermodel, newuser.Password);
                if (result.Succeeded)
                {
                    //create cookie
                    await signInManager.SignInAsync(usermodel, isPersistent: false);

                    return RedirectToAction("Index", "Dept");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(newuser);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Login", "Acount");
        }
    }
}
