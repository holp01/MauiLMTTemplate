namespace MauiLMTTemplate.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> LoginUserNamePassword(string username, string password);
    }
}