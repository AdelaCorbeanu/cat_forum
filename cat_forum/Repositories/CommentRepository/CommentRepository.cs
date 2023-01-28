using cat_forum.Models;
using cat_forum.Repositories.GenericRepository;
using cat_forum.Data;
using Microsoft.EntityFrameworkCore;

namespace cat_forum.Repositories.CommentRepository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {

        public CommentRepository (CatForumContext catForumContext) : base(catForumContext)
        {

        }

        public async Task<IEnumerable<Comment>> GetCommentsByPost (Guid postId)
        {
            return await _context.Comments
                .Join(_context.Users,
                      c => c.UserId,
                      u => u.Id,
                      (c, u) => new { Comment = c, User = u })
                .Where(cm => cm.Comment.ForumPostId == postId)
                .Select(cm => cm.Comment)
                .ToListAsync();
        }

        public async Task<Comment> GetComment (Guid id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment> AddComment (Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> UpdateComment (Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> DeleteComment (Guid id)
        {
            var comment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}
