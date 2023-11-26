using System.Security.Claims;
using Forest.Data;
using Forest.Models;
using Forest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forest.Controllers
{

    public class ArticleController : Controller
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly AppDbContext _context;

        public ArticleController(AppDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public IActionResult Detail(int id)
        {
            var findArticle = _context.Articles.Include(x=>x.ArticleTags).ThenInclude(x=>x.Tag).SingleOrDefault(x=>x.Id == id);
            var next = _context.Articles.Where(x => x.Id > id).Take(1).FirstOrDefault();
            var prev = _context.Articles.OrderByDescending(x => x.Id).Where(x => x.Id < id).Take(1).FirstOrDefault();
            var similar = _context.Articles.Where(x => x.CategoryId == findArticle.CategoryId).OrderByDescending(x => x.ViewCount).Take(2).ToList();
            var comments = _context.Comments.Include(x=>x.User).Where(x=>x.ArticleId == id).ToList();
            
            
            DetailVM detailVM = new()
            {
                Article = findArticle,
                NextPost = next,
                PrevPost = prev,
                SimilarPost = similar,
                Comments = comments
            };


            var cookie = Request.Cookies["User"];
            if (cookie == null || !cookie.Split(",").Contains(id.ToString()))
            {
                 List<int> ids = new();

            var result = cookie == null ? "" : String.Join(",", cookie.Split(",").ToList());

            var cookiData = id.ToString() + "," + String.Concat(result);

            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(15);
            cookieOptions.Path = "/";
            Response.Cookies.Append("user", cookiData, cookieOptions);
            findArticle.ViewCount++;
            _context.SaveChanges();
            }
        return View(detailVM);
        }


    
         [HttpPost]
    public IActionResult AddComment(Comment comment)
    {
        comment.UserId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        _context.Comments.Add(comment);
        _context.SaveChanges();
        return RedirectToAction("Index","Home");
    }


    }
}    