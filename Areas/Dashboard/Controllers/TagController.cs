using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Forest.Data;
using Forest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Forest.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles ="Admin, Moderator")]
    public class TagController : Controller
    {
        private readonly AppDbContext _context;

        public TagController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var tags = _context.Tags.Include(x=>x.ArticleTags).ThenInclude(x=>x.Article).ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string tagName)
        {
            if (string.IsNullOrWhiteSpace(tagName))
            return View();
            var findtag = _context.Tags.FirstOrDefault(x=>x.TagName == tagName);
            if (findtag != null)
            return View();
            Tag tag = new()
            {
                TagName = tagName,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            return RedirectToAction("Index");
        }


    }
}
