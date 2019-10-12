using System.Threading.Tasks;
using RollerCoaster2019.Contracts;

namespace RollerCoaster2019.Services
{
    public interface IAuthenticationService
    {
        Task<LoginDescriptor> Login(string username, string password);
        Task<LogoutDescriptor> Logout(string token);
    }
}