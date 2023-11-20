

using Forest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forest.Controllers;


//[Authorize(Roles = "Admin")]
public class AuthController : Controller
{

    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }



    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Register()
    {
        return View();
    }

}