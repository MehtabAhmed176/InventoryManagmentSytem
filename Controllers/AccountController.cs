using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagment.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagment.Controllers
{
    public class AccountController : Controller
    {

      
            private readonly UserManager<IdentityUser> userManager;
            private readonly SignInManager<IdentityUser> signInManager;

            public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
            {
                this.userManager = userManager;
                this.signInManager = signInManager;
            }
            public IActionResult Index()
            {
                return View();
            }

            public async Task<IActionResult> RegistorAsync(RegistorViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser() { UserName = model.Email, Email = model.Email };
                    var result = await userManager.CreateAsync(user, model.password);
                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("index", "home");

                    }
                    foreach (var errors in result.Errors)
                    {
                        ModelState.AddModelError("", errors.Description);
                    }

                }



                return View();
            }

            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }
        [HttpPost]
        public IActionResult LoginSave(LoginViewModel model)
        {
            return View();
        }



        [HttpPost]
            public async Task<IActionResult> Logout()
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("index", "home");
            }


        }
    }

