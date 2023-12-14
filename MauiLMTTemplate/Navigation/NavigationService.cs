using MauiLMTTemplate.Services.Settings;

namespace MauiLMTTemplate.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly ISettingsService _settingsService;

        public NavigationService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        //Edit this to Whatever screen is your first screen
        public Task InitializeAsync() => NavigateToAsync("");

        public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
        {
            return routeParameters != null
                ? Shell.Current.GoToAsync(route, routeParameters)
                : Shell.Current.GoToAsync(route);
        }

        public Task PopAsync() => Shell.Current.GoToAsync("..");
    }
}
