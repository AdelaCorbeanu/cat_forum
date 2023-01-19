using cat_forum.Helpers.JwtToken;
using cat_forum.Models;
using cat_forum.Models.DTOs;
using cat_forum.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace cat_forum.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        private IJwtUtils _jwtUtils;

        public UserService (IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }

        public UserResponseDTO Authenticate (UserRequestDTO model)
        {
            var user = _userRepository.FindByUsername(model.UserName);
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null;
            }

            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public async Task Create (User newUser)
        {
            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
        }

        public User GetById (Guid id)
        {
            return _userRepository.FindById(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return (List<User>)_userRepository.GetAllAsync();
        }
    }
}
