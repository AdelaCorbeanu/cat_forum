using cat_forum.Models;
using Microsoft.EntityFrameworkCore;

namespace cat_forum.Data
{
    public class CatForumContext : DbContext
    {
        public DbSet<ForumPost> ForumPosts { get; set; }
        public CatForumContext(DbContextOptions<CatForumContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
