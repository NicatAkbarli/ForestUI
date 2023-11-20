using Forest.Data;
using Forest.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Forest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;


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

        return View(homeVM);
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
