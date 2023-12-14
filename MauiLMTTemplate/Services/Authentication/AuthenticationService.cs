using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLMTTemplate.Services.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService()
        {

        }

        public async Task<bool> LoginUserNamePassword(string username, string password)
        {
            // Implement your authentication logic here
            return true;
        }
    }
}
