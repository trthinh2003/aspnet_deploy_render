using Microsoft.AspNetCore.Mvc;
using razorweb.Models;
using razorweb.ViewModels;

namespace razorweb.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly MyBlogContext _context;
        public ArticlesController(MyBlogContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var articles = _context.Articles.AsQueryable();
            var result = articles.Select(a => new ArticleVM
            {
                Id = a.Id,
                Title = a.Title,
                CreateAt = a.CreateAt,
                Content = a.Content
            });

            return View(result);
        }
    }
}
