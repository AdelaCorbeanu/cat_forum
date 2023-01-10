using cat_forum.Models.Base;

namespace cat_forum.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<ForumPost> ForumPosts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CatHumanRelation> CatHumanRelations { get; set; }
    }
}
