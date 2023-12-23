using Microsoft.Identity.Client;

namespace MauiLMTTemplate.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> LoginUserNamePassword(string username, string password);

        Task<AuthenticationResult> LoginMSALAsync(CancellationToken cancellationToken);
    }
}