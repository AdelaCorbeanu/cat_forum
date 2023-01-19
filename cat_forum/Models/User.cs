using cat_forum.Models.Base;
using cat_forum.Models.Enums;
using System.Text.Json.Serialization;

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
        public string UserName { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
    }
}
