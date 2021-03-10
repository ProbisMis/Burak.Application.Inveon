using Burak.Application.Inveon.Data.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Business.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> GetUserById(int userId);
        Task<User> DeleteUser(User user);
        Task<User> GetUserByUsername(string username);
    }
}
