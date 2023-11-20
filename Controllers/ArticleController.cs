using Microsoft.AspNetCore.Mvc;

namespace Forest.Controllers
{

    public class ArticleController : Controller
    {
         private readonly ILogger<ArticleController> _logger;

         public ArticleController(ILogger<ArticleController> logger)
        {
            _logger = logger;
        }

         public IActionResult Index()
        {
            return View();
        }
         public IActionResult Detail(int id)
        {
            return View();
        }
    }
}    