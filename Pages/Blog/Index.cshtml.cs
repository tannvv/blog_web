using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using blog_web;

namespace blog_web.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly blog_web.ArticleContext _context;

        public const int ITEMS_PER_PAGE = 10;

        [BindProperty(SupportsGet =true, Name ="p")]
        public int CurrentPage { get; set; }
        public int CountPage { get; set; }
        

        public IndexModel(blog_web.ArticleContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync(string SearchString)
        {

            int totalArticle = await _context.articles.CountAsync();
            CountPage = (int)Math.Ceiling((double)totalArticle/ITEMS_PER_PAGE);
            if(CurrentPage < 0){
                CurrentPage = 1;
            }
            if (CurrentPage > CountPage )
            {
                CurrentPage = CountPage;
            }

            var qr = (from a in _context.articles
                     orderby a.Created descending
                     select a).Skip((CurrentPage -1)*ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE);
            if (!string.IsNullOrEmpty(SearchString))
            {
                Article = qr.Where(a => a.Title.Contains(SearchString)).ToList();
            }
            else
            {
                Article = await qr.ToListAsync();
            }
        }
    }
}
