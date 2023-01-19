using AutoMapper;
using cat_forum.Models;
using cat_forum.Models.DTOs;
using cat_forum.Repositories.PostRepository;

namespace cat_forum.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService (IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public PostDTO GetPostMappedByTitle (string title)
        {
            ForumPost forumPost = _postRepository.GetByTitle (title);
            PostDTO postResult = _mapper.Map<PostDTO>(forumPost); 
            return postResult;
        }

        public IEnumerable<PostDTO> GetPostMappedByUserId (Guid id)
        {
            IEnumerable<ForumPost> forumPosts = _postRepository.GetByUserId (id);
            IEnumerable<PostDTO> postsResult = forumPosts.Select(p => _mapper.Map<PostDTO>(p));
            return postsResult;
        }
    }
}
