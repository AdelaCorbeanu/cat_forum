using cat_forum.Data;
using cat_forum.Models;
using cat_forum.Models.Enums;
using cat_forum.Repositories.GenericRepository;

namespace cat_forum.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository (CatForumContext context) : base(context)
        {

        }

        public User FindByUsername (string username)
        {
            return _table.FirstOrDefault(u => u.UserName == username);
        }

        public IEnumerable<User> GetAllAsync()
        {
            var users = _table.ToList();
            return users.Where(x => x.Role == Role.User);

        }
    }
}
