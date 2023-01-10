using cat_forum.Models.Base;

namespace cat_forum.Models
{
    public class CatProfile : BaseEntity
    {
        public String EyeColor { get; set; }
        public String? Weight { get; set; }
        public int BirthYear { get; set; }
        public String MomBreed { get; set; }
        public String DadBreed { get; set; }
        public String? AdditionalDetails { get; set; }
        public Cat Cat { get; set; }
        public Guid CatId { get; set; }
    }
}
