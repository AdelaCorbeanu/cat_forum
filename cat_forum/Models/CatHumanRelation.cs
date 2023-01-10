namespace cat_forum.Models
{
    public class CatHumanRelation
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CatId { get; set; }
        public Cat Cat { get; set; }
    }
}
