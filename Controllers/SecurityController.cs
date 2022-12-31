using CRUD1.Security;
using CRUD1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRUD1.Controllers
{
    public class SecurityController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly RoleManager<AppIdentityRole> roleManager;
        private readonly SignInManager<AppIdentityUser> signInManager;

        public SecurityController(UserManager<AppIdentityUser> userManager, RoleManager<AppIdentityRole> roleManager, SignInManager<AppIdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;

            createAdminRoleAndAccount();
            createEmployeeRole();
        }
        
        private void createAdminRoleAndAccount()
        {

            if (!roleManager.RoleExistsAsync("admin").Result)
            {
                AppIdentityRole role = new AppIdentityRole();
                role.Name = "admin";
                role.Description = "Puede realizar operaciones CRUD.";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            AppIdentityUser user = new AppIdentityUser();
            user.UserName = "admin";
            user.Email = "admin@admins.com";
            user.FullName = "admin";
            user.BirthDate = DateTime.Now;

            IdentityResult result = userManager.CreateAsync(user, "Contra!99").Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, "admin").Wait();
            }
            else
            {
                ModelState.AddModelError("", "Los datos de admin son invalidos.");
            }
        }

        private void createEmployeeRole()
        {

            if (!roleManager.RoleExistsAsync("employee").Result)
            {
                AppIdentityRole role = new AppIdentityRole();
                role.Name = "employee";
                role.Description = "Puede realizar operaciones CRUD.";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }


        public IActionResult Register()
        {
            return View();
        }

        // https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Register obj)
        {
            // TODO mejor crear rol admin y usuario admin al arrancar la app

            if (ModelState.IsValid)
            {
                if (!roleManager.RoleExistsAsync("client").Result)
                {
                    AppIdentityRole role = new AppIdentityRole();
                    role.Name = "client";
                    role.Description = "Puede comprar en la tienda.";
                    IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                }

                AppIdentityUser user = new AppIdentityUser();
                user.UserName = obj.UserName;
                user.Email = obj.Email;
                user.FullName = obj.FullName;
                user.BirthDate = obj.BirthDate;

                IdentityResult result = userManager.CreateAsync(user, obj.Password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "client").Wait();
                    return RedirectToAction("SignIn", "Security");
                }
                else
                {
                    ModelState.AddModelError("", "Los datos de usuario son invalidos.");
                }
            }

            return View(obj);
        }
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(SignIn obj)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(obj.UserName, obj.Password, obj.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Los datos de usuario son invalidos.");
                }
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignOutSimple()
        {
            signInManager.SignOutAsync().Wait();
            Console.WriteLine("yes");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
