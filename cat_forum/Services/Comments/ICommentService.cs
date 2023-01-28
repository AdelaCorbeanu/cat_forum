using cat_forum.Models.DTOs;

namespace cat_forum.Services.Comments
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDTO>> GetCommentsByPost (Guid postId);
        Task<CommentDTO> GetComment (Guid id);
        Task<CommentDTO> AddComment (CommentDTO comment);
        Task<CommentDTO> UpdateComment (CommentDTO comment);
        Task<CommentDTO> DeleteComment (Guid id);
    }
}
