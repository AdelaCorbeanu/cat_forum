using cat_forum.Models;
using Microsoft.EntityFrameworkCore;

namespace cat_forum.Data
{
    public class CatForumContext : DbContext
    {
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<CatProfile> CatProfiles { get; set; }

        public CatForumContext(DbContextOptions<CatForumContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.ForumPosts)
                .WithOne(fp => fp.User)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ForumPost>()
                .HasMany(fp => fp.Comments)
                .WithOne(c => c.ForumPost);

            modelBuilder.Entity<CatHumanRelation>()
                .HasKey(r => new { r.CatId, r.UserId });
            
            modelBuilder.Entity<CatHumanRelation>()
                .HasOne(r => r.User)
                .WithMany(u => u.CatHumanRelations)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<CatHumanRelation>()
                .HasOne(r => r.Cat)
                .WithMany(c => c.CatHumanRelations)
                .HasForeignKey(r => r.CatId);

            modelBuilder.Entity<Cat>()
                .HasOne(c => c.CatProfile)
                .WithOne(cp => cp.Cat)
                .HasForeignKey<CatProfile>(cp => cp.CatId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
