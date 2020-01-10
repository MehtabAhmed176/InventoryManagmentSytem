using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Data;
using InventoryManagement.Models;
using InventoryManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
   // [Authorize]
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this._context = context;
          
        }


       



        [HttpGet]
        public IActionResult Index()
        {
            var users = userManager.Users;

            //ApplicationUser allusers = new ApplicationUser();
            // IList<ApplicationUser> mysuers =allusers.UserBranchId. (s => s.ServiceId == 3).First().Branches.ToList();

            //  var result = from allusers in _context.Users.Contains(x=>x.UserBranchId==Branch);
            //             where men.Women.Any(women => women.Id == 1)
            //           select men

            var result = from parent in _context.Users

                         join child in _context.Branches on parent.UserBranchId equals child.BranchId into all
                         select all;

   


            return View(users);
        }


        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
      
        public async Task<IActionResult> CreateUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    UserBranchId = model.BranchId
                    
                };

                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                var result = await userManager.CreateAsync(user, model.Password);
                var roleresult=await roleManager.CreateAsync(identityRole);

                if (result.Succeeded&& roleresult.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}