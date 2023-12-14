using CommunityToolkit.Maui;
using MauiLMTTemplate.Services.Settings;
using MauiLMTTemplate.ViewModels;
using MauiLMTTemplate.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;

namespace MauiLMTTemplate
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder app)
        {
            //Add all you Services here

            app.Services.AddSingleton<INavigationService, NavigationService>();
            app.Services.AddSingleton<ISettingsService, SettingsService>();

            return app;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder app)
        {
            //Add all your ViewModels here

            app.Services.AddSingleton<MainPageViewModel>();
            app.Services.AddSingleton<LoginViewModel>();

            return app;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder app)
        {
            //Add all your Views here - All Views should be Transient.

            app.Services.AddTransient<MainPageView>();
            app.Services.AddTransient<LoginPageView>();

            return app;
        }
    }
}
