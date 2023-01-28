using AutoMapper;
using cat_forum.Models.DTOs;
using cat_forum.Models;
using cat_forum.Repositories.CommentRepository;

namespace cat_forum.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService (ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDTO>> GetCommentsByPost (Guid postId)
        {
            var comments = await _commentRepository.GetCommentsByPost(postId);
            return _mapper.Map<List<CommentDTO>>(comments);
        }

        public async Task<CommentDTO> GetComment (Guid id)
        {
            var comment = await _commentRepository.GetComment(id);
            return _mapper.Map<CommentDTO>(comment);
        }

        public async Task<CommentDTO> AddComment (CommentDTO comment)
        {
            var commentModel = _mapper.Map<Comment>(comment);
            var addedComment = await _commentRepository.AddComment(commentModel);
            return _mapper.Map<CommentDTO>(addedComment);
        }

        public async Task<CommentDTO> UpdateComment (CommentDTO comment)
        {
            var commentModel = _mapper.Map<Comment>(comment);
            var updatedComment = await _commentRepository.UpdateComment(commentModel);
            return _mapper.Map<CommentDTO>(updatedComment);
        }

        public async Task<CommentDTO> DeleteComment(Guid id)
        {
            var deletedComment = await _commentRepository.DeleteComment(id);
            return _mapper.Map<CommentDTO>(deletedComment);
        }
    }
}
