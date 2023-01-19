using System.ComponentModel.DataAnnotations;

namespace cat_forum.Models.DTOs
{
    public class UserRequestDTO
    {
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
