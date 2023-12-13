using MauiLMTTemplate.Services.Settings;
using MauiLMTTemplate.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLMTTemplate.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;

        [ObservableProperty]
        private string _location;

        public MainPageViewModel(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public override Task InitializeAsync()
        {
            Location = _settingsService.Location;

            return base.InitializeAsync();
        }
    }
}
