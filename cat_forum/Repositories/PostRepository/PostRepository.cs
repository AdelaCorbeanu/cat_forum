using cat_forum.Data;
using cat_forum.Models;
using cat_forum.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace cat_forum.Repositories.PostRepository
{
    public class PostRepository : GenericRepository<ForumPost>, IPostRepository
    {
        public PostRepository(CatForumContext catForumContext) : base(catForumContext)
        {

        }

        public void OrderByDate()
        {
            var postsOrderNewest = _table.OrderByDescending(x => x.DateCreated);

            var postsOrderNewest2 = from p in _table
                                     orderby p.DateCreated descending
                                     select p;
        }

        public ForumPost GetByTitle (string title)
        {
            return _table.FirstOrDefault(x => x.Title.ToLower().Trim().Equals(title.ToLower().Trim()));
        }

        public async Task<IEnumerable<ForumPost>> GetByUserIdAsync (Guid id)
        {
            return await _context.ForumPosts
                .Include(p => p.User)
                .Where(p => p.UserId == id)
                .ToListAsync();
        }
    }
}
