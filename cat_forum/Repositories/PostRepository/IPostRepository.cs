using cat_forum.Models;
using cat_forum.Repositories.GenericRepository;

namespace cat_forum.Repositories.PostRepository
{
    public interface IPostRepository : IGenericRepository<ForumPost>
    {
        public void OrderByDate ();
        ForumPost GetByTitle (string title);
        IEnumerable<ForumPost> GetByUserId (Guid id);
    }
}
