using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace blog_web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ArticleContext _articleContext;

        public List<Article> posts;

        public IndexModel(ILogger<IndexModel> logger, ArticleContext articleContext)
        {
            _logger = logger;
            _articleContext = articleContext;
        }

        public void OnGet()
        {
            List<Article> posts = (from a in _articleContext.articles
                                   orderby a.Created  select a).ToList();
            ViewData["posts"] = posts;
        }
    }
}
