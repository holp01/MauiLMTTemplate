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
                .RegisterAppServices()
                .RegisterViewModels()
                .RegisterViews();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder app)
        {
            app.Services.AddSingleton<ISettingsService, SettingsService>();

            return app;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder app)
        {
            app.Services.AddSingleton<MainPageViewModel>();

            return app;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder app)
        {
            app.Services.AddSingleton<MainPageView>();

            return app;
        }
    }
}
