using cat_forum.Models;

namespace cat_forum.Helpers.JwtToken
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken (User user);
        public Guid ValidateJwtToken (string token);
    }
}
