using MauiLMTTemplate.Models.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLMTTemplate.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        private IPublicClientApplication authenticationClient;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> LoginUserNamePassword(string username, string password)
        {
            // Implement your authentication logic here
            return true;
        }


        public async Task<AuthenticationResult> LoginMSALAsync(CancellationToken cancellationToken)
        {
            var authenticationSection = _configuration.GetSection("Authentication").Get<AuthenticationConfig>();

            authenticationClient = PublicClientApplicationBuilder.Create(authenticationSection.ClientId)
                .WithRedirectUri($"msal{authenticationSection.ClientId}://auth")
                .Build();

            AuthenticationResult result;
            try
            {

                result = await authenticationClient
                    .AcquireTokenInteractive(authenticationSection.Scopes)
#if ANDROID
                   .WithParentActivityOrWindow(Platform.CurrentActivity)
#endif
                    .WithPrompt(Prompt.SelectAccount) //This is optional. If provided, on each execution, the username and the password must be entered.
                    .ExecuteAsync(cancellationToken);
                return result;
            }
            catch (MsalClientException)
            {
                return null;
            }
        }
    }
}
