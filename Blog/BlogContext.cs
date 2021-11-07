using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI
{
    public class BlogContext : DbContext
    {
        public virtual DbSet<BlogItem> BlogItems { get; set; }
        
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }
    }
}
