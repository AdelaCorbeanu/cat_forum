using cat_forum.Models.Base;

namespace cat_forum.Models
{
    public class ForumPost : BaseEntity
    {
        public String Title { get; set; }
        public String Content { get; set; }
        public User? User { get; set; }
        public Guid? UserId { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
