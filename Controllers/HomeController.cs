using System.Diagnostics;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Forest.Data;
using Forest.Models;
using Forest.ViewModels;


namespace Forest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly  AppDbContext _context;

    
    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
         var articles = _context.Articles.ToList();
        var categories = _context.Categories.ToList();
        var users = _context.Users.ToList();
        
        
        HomeVM homeVM = new()
        {
            User = users,
            Article = articles,
            Category = categories


        };
       
        return View();
    }
     public IActionResult Detail()
    {
        return View();
    }

    public IActionResult Privacy()
    {
    
        return View();
    }

}
