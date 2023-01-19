using cat_forum.Models;
using cat_forum.Repositories.GenericRepository;

namespace cat_forum.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindByUsername (string username);
        IEnumerable<User> GetAllAsync();
    }
}
