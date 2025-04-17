using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using razorweb.Models;

namespace razorweb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyBlogContext _context;

    public HomeController(ILogger<HomeController> logger, MyBlogContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var posts = (from p in _context.Articles
                    orderby p.CreateAt descending
                    select p).ToList();
        ViewData["posts"] = posts;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
