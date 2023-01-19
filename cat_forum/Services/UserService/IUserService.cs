using cat_forum.Models;
using cat_forum.Models.DTOs;

namespace cat_forum.Services.UserService
{
    public interface IUserService
    {
        UserResponseDTO Authenticate (UserRequestDTO model);
        User GetById (Guid id);
        Task Create (User newUser);
        Task<List<User>> GetAllUsers();
    }
}
