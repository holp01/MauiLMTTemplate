using MauiLMTTemplate.Services.Authentication;
using MauiLMTTemplate.ViewModels.Base;
using System;
using System.Collections.Generic;
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
    }
}
