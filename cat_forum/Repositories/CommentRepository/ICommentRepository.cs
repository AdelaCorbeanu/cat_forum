using cat_forum.Models;
using cat_forum.Repositories.GenericRepository;

namespace cat_forum.Repositories.CommentRepository
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsByPost (Guid postId);
        Task<Comment> GetComment (Guid id);
        Task<Comment> UpdateComment (Comment comment);
        Task<Comment> AddComment (Comment comment);
        Task<Comment> DeleteComment (Guid id);

    }
}
