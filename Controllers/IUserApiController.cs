using Burak.Application.Inveon.Models.Request;
using Burak.Application.Inveon.Models.Response;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Controllers
{
    public interface IUserApiController
    {

          Task<UserResponse> Authenticate(LoginRequest userRequest);

          Task<UserResponse> CreateUser(UserRequest userRequest);

          Task<UserResponse> UpdateUser(UserRequest userRequest);

          Task<UserResponse> DeleteUser(int userId);

          Task<UserResponse> GetUser(int userId);
    }
}