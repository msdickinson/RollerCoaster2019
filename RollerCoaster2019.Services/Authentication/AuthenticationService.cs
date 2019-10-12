using RollerCoaster2019.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RollerCoaster2019.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<LoginDescriptor> Login(string username, string password)
        {
            await Task.CompletedTask;

            return new LoginDescriptor();
        }

        public async Task<LogoutDescriptor> Logout(string token)
        {
            await Task.CompletedTask;

            return new LogoutDescriptor();
        }
    }
}
