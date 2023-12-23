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
        private IPublicClientApplication authenticationClient;

        public AuthenticationService()
        {

        }

        public async Task<bool> LoginUserNamePassword(string username, string password)
        {
            // Implement your authentication logic here
            return true;
        }


        public async Task<AuthenticationResult> LoginMSALAsync(CancellationToken cancellationToken)
        {
            authenticationClient = PublicClientApplicationBuilder.Create(Constants.ClientId)
                .WithRedirectUri($"msal{Constants.ClientId}://auth")
                .Build();

            AuthenticationResult result;
            try
            {
                result = await authenticationClient
                    .AcquireTokenInteractive(Constants.Scopes)
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
