using CommunityToolkit.Maui.Alerts;
using MauiLMTTemplate.Services.Authentication;
using MauiLMTTemplate.ViewModels.Base;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiLMTTemplate.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _password;

        private readonly IAuthenticationService _authenticationService;

        public LoginViewModel(INavigationService navigationService,
            IAuthenticationService authenticationService)
            : base(navigationService)
        {
            _authenticationService = authenticationService;
        }

        public override Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        [RelayCommand]
        private async Task SignInAsync()
        {
            await IsBusyFor(
                async () =>
                {
                    await Task.Delay(10);

                    //Change this to whatever implementation you prefer
                    if (await _authenticationService.LoginUserNamePassword(UserName, Password))
                        await _navigationService.NavigateToAsync("//Main/Projects");
                });
        }

        [RelayCommand]
        private async Task LoginMSALAsync()
        {
            await IsBusyFor(
                async () =>
                {
                    try
                    {
                        var result = await _authenticationService.LoginMSALAsync(CancellationToken.None);
                        var token = result?.IdToken; // AccessToken also can be used
                        if (token != null)
                        {
                            var handler = new JwtSecurityTokenHandler();
                            var data = handler.ReadJwtToken(token);
                            var claims = data.Claims.ToList();
                            if (data != null)
                            {
                                var stringBuilder = new StringBuilder();
                                stringBuilder.AppendLine($"Name: {data.Claims.FirstOrDefault(x => x.Type.Equals("name"))?.Value}");
                                stringBuilder.AppendLine($"Email: {data.Claims.FirstOrDefault(x => x.Type.Equals("preferred_username"))?.Value}");
                                await Toast.Make(stringBuilder.ToString()).Show();
                            }
                        }
                    }
                    catch (MsalClientException ex)
                    {
                        await Toast.Make(ex.Message).Show();
                    }
                });
        }
    }
}
