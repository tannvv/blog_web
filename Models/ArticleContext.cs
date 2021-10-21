using Microsoft.EntityFrameworkCore;

namespace blog_web{

    public class ArticleContext : DbContext{
        
        public ArticleContext(DbContextOptions<ArticleContext> options) : base(options){

        }
        public DbSet<Article> articles{set;get;}
    }

}