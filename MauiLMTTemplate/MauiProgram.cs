using CommunityToolkit.Maui;
using MauiLMTTemplate.Services.Authentication;
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
                    fonts.AddFont("Font_Awesome_5_Free-Regular-400.otf", "FontAwesome-Regular");
                    fonts.AddFont("Font_Awesome_5_Free-Solid-900.otf", "FontAwesome-Solid");
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
            app.Services.AddSingleton<IAuthenticationService, AuthenticationService>();

            return app;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder app)
        {
            //Add all your ViewModels here

            app.Services.AddSingleton<LoginViewModel>();
            app.Services.AddSingleton<ProjectViewModel>();
            app.Services.AddSingleton<ProjectDetailViewModel>();

            return app;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder app)
        {
            //Add all your Views here - All Views should be Transient.

            app.Services.AddTransient<LoginView>();
            app.Services.AddTransient<ProjectsView>();
            app.Services.AddTransient<ProjectDetailView>();

            return app;
        }
    }
}
