using System.Collections.Generic;
using System.Threading.Task;

namespace DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<bool> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
