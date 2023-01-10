using cat_forum.Models.Base;

namespace cat_forum.Models
{
    public class Cat : BaseEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String Breed { get; set; }
        public ICollection<CatHumanRelation> CatHumanRelations { get; set; }
        public CatProfile CatProfile { get; set; }
    }
}
