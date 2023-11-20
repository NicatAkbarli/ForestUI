using Forest.Data;
using Forest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forest.Areas.Dashboard.Controllers
{
    [Area("[Dashboard")]
    [Authorize]
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
            return View(categories);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string categoryName)
        {
            Category category= new()
            {
                UpdatedDate = DateTime.Now,
                CreatedDate= DateTime.Now,
                CategoryName= categoryName
            };
            
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}