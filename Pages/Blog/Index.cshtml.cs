using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorweb.Models;

namespace razorweb.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly razorweb.Models.MyBlogContext _context;

        public IndexModel(razorweb.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Article = await _context.Articles.ToListAsync();
        }
    }
}
