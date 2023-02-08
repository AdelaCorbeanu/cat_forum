using cat_forum.Models;
using cat_forum.Models.DTOs;

namespace cat_forum.Services.Posts
{
    public interface IPostService
    {
        Task AddAsync(ForumPost newPost);
        PostDTO GetPostMappedByTitle (string title);
        IEnumerable<PostDTO> GetPostMappedByUserId (Guid id);
        Task SaveChangesAsync();
    }
}
