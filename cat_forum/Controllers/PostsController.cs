using cat_forum.Data;
using cat_forum.Models;
using cat_forum.Models.DTOs;
using cat_forum.Services.Comments;
using cat_forum.Services.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cat_forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        /*
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            return Ok(await _postService.GetPostMappedByTitle();
        }
        */

        [HttpGet("postById/{id}")]
        public async Task<IActionResult> GetPostById([FromRoute] Guid id)
        {
            var postById = _postService.GetPostMappedByUserId(id);

            return Ok(postById);
        }

        [HttpGet("postById/{title}")]
        public async Task<IActionResult> GetPostById(string title)
        {
            var postById = _postService.GetPostMappedByTitle(title);

            return Ok(postById);
        }

        [HttpPost("CreatePost")]
        public async Task<IActionResult> Create(PostDTO postDTO)
        {
            var newPost = new ForumPost();

            newPost.Title = postDTO.Title;
            newPost.Content = postDTO.Content;

            await _postService.AddAsync(newPost);
            await _postService.SaveChangesAsync();
            return Ok(newPost);
        }
    }
}
