using cat_forum.Models.DTOs;

namespace cat_forum.Services.Posts
{
    public interface IPostService
    {
        PostDTO GetPostMappedByTitle (string title);
        IEnumerable<PostDTO> GetPostMappedByUserId (Guid id);
    }
}
