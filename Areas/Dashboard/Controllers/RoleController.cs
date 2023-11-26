using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Forest.Areas.Dashboard.Controllers
{
   [Area("Dashboard")]
   [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Craete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var findRole = await _roleManager.FindByNameAsync(roleName);
            if (findRole != null)
            {
                return View();
            } 

            IdentityRole newRole = new()
            {
                Name = roleName
            };
            await _roleManager.CreateAsync(newRole);
            return RedirectToAction("Index");
        }

    }
}