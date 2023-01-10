using cat_forum.Data;
using cat_forum.Models;
using cat_forum.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cat_forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private CatForumContext _forumContext;

        public PostsController(CatForumContext forumContext)
        {
            _forumContext = forumContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            return Ok(await _forumContext.ForumPosts.ToListAsync());
        }

        [HttpGet("postById/{id}")]
        public async Task<IActionResult> GetPostById([FromRoute] Guid id)
        {
            var postById = _forumContext.ForumPosts.FirstOrDefault(x => x.Id == id);

            return Ok(postById);
        }

        [HttpPost("CreatePost")]
        public async Task<IActionResult> Create(PostDTO postDTO)
        {
            var newPost = new ForumPost();

            newPost.Title = postDTO.Title;
            newPost.Content = postDTO.Content;

            await _forumContext.AddAsync(newPost);
            await _forumContext.SaveChangesAsync();
            return Ok(newPost);
        }
    }
}
