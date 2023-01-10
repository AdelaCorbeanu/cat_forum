using cat_forum.Models.Base;

namespace cat_forum.Models
{
    public class Comment : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public User? User { get; set; }
        public Guid? UserId { get; set; }
        public ForumPost ForumPost { get; set; }
        public Guid ForumPostId { get; set; }
    }
}
