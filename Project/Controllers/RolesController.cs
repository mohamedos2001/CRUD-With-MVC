using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.ViewModel;

namespace Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            this.roleManager = roleManager;
            userManager = _userManager;
            signInManager = _signInManager;
        }
        
        //create role
        //link
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> New(RoleViewModel newrole)
        {
            if (ModelState.IsValid) {
                IdentityRole role = new IdentityRole();
                role.Name = newrole.RoleName;
                IdentityResult result= await roleManager.CreateAsync(role);
                if (result.Succeeded) { 
                
                        return View(new RoleViewModel());
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(newrole);
        }
    }
}
