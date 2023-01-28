using Microsoft.AspNetCore.Mvc;
using cat_forum.Models.DTOs;
using cat_forum.Services.Comments;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController (ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("post/{postId}")]
        public async Task<IEnumerable<CommentDTO>> GetCommentsByPost (Guid postId)
        {
            return await _commentService.GetCommentsByPost(postId);
        }

        [HttpGet("{id}")]
        public async Task<CommentDTO> GetComment (Guid id)
        {
            return await _commentService.GetComment(id);
        }

        [HttpPost]
        public async Task<CommentDTO> AddComment (CommentDTO comment)
        {
            return await _commentService.AddComment(comment);
        }

        [HttpPut("{id}")]
        public async Task<CommentDTO> UpdateComment (Guid id, CommentDTO comment)
        {
            comment.Id = id;
            return await _commentService.UpdateComment(comment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment (Guid id)
        {
            var comment = await _commentService.GetComment(id);
            if (comment == null)
            {
                return NotFound();
            }

            var currentUser = HttpContext.User;

            if (!currentUser.Identity.IsAuthenticated) return Forbid();

            if (currentUser.IsInRole("Admin"))
            {
                await _commentService.DeleteComment(id);
                return NoContent();
            }
            else
            {
                return Forbid();
            }
        }

    }
}
