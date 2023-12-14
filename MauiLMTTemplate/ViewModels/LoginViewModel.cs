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

        public LoginViewModel(INavigationService navigationService)
            : base(navigationService)
        {

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
                });

            await _navigationService.NavigateToAsync("//Main/Projects");
        }
    }
}
