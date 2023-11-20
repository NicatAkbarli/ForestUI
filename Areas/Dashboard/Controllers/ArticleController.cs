

using Microsoft.AspNetCore.Mvc;

namespace Forest.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}