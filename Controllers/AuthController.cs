

using System.Security.Claims;
using Forest.Dtos;
using Forest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forest.Controllers;


[Authorize(Roles = "Admin")]
public class AuthController : Controller
{
     private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IHttpContextAccessor _httpContext;

    public AuthController(IHttpContextAccessor httpContext, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {
        _httpContext = httpContext;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _userManager = userManager;
    }


    public IActionResult Login()
    {
        var user = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user != null)
        {
            return RedirectToAction("Index","Home");
        }
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var findUser = await _userManager.FindByEmailAsync(loginDto.Email);
        if (findUser == null)
        {
            return View();
        }
        var result = await _signInManager.PasswordSignInAsync(findUser,loginDto.Password,true,true);
        if (result.Succeeded)
        {
            return RedirectToAction("Index","Home");
        }
        return View();
    }


      [HttpGet] // Attribute
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var findUser = await _userManager.FindByEmailAsync(registerDto.Email);

        if (findUser != null)
            return View();
    
    User newUser = new()
    {
        FirstName = registerDto.FirstName,
        LastName = registerDto.LastName,
        Email = registerDto.Email,
        UserName = registerDto.Email,
        PhotoUrl = "/",
        About = " ",
        ConfirmationToken = Guid.NewGuid().ToString()
    };

    IdentityResult result = await _userManager.CreateAsync(newUser, registerDto.Password);
    

    if (result.Succeeded)
    {
        await _userManager.AddToRoleAsync(newUser, "User");
        return RedirectToAction("Login");
    }
    return View();


    }

    public IActionResult Forgot()
    {
            return View();
    }

    
    public IActionResult Logout()
    {

        _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }


}