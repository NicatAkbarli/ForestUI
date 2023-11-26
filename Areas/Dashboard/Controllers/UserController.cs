using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Forest.Areas.Dashboard.ViewModels;
using Forest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Forest.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
        public class UserController : Controller
    {
      private readonly UserManager<User> _userManager;
      private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        public async Task<IActionResult> AddRole(string id)
        {
            var roles = _roleManager.Roles.ToList();
            var user =await _userManager.FindByIdAsync(id);

            UserRoleVM userVm = new()
            {
                Roles = roles,
                User = user
            };
            return View(userVm);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName,string userId)
        {
            var findUser = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(findUser);
            await _userManager.RemoveFromRolesAsync(findUser, userRoles);
            var addRole = await _userManager.AddToRoleAsync(findUser,roleName);

            if (addRole.Succeeded)
            {
                return View("Index");
            }
            return View();
        }



    }
}