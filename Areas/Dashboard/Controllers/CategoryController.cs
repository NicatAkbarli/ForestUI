using Forest.Data;
using Forest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Forest.Areas.Dashboard.Controllers
{[Area("Dashboard")]
[Authorize(Roles = ("Admin, Moderator"))]
public class CategoryController : Controller
{
    private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View();
        }

        
    [HttpGet]
    [Authorize(Roles = ("Moderator"))]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(string categoryName)
    {
        Category category = new()
        {
            UpdatedDate = DateTime.Now,
            CreatedDate = DateTime.Now,
            CategoryName = categoryName
        };
        _context.Categories.Add(category);
        _context.SaveChanges();


        return RedirectToAction("Index");
    }


    [HttpPost]
    public IActionResult Edit(int id)
    {
        var category = _context.Categories.SingleOrDefault(x=>x.Id == id);
        return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        category.UpdatedDate = DateTime.Now;
        _context.Categories.Update(category);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    
}
}