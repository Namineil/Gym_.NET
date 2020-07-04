using System.Threading.Tasks;
using Gym.API.Domain.Models;

namespace Gym.API.Domain.Services {
    public interface IAuthService
    {
        Task<User> Authenticate(string Login, string Password);
    }
}