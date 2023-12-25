using CommunityToolkit.Maui;
using MauiLMTTemplate.Services.Authentication;
using MauiLMTTemplate.Services.Azure;
using MauiLMTTemplate.Services.Settings;
using MauiLMTTemplate.ViewModels;
using MauiLMTTemplate.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;
using System.Reflection;

namespace MauiLMTTemplate
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.ConfigureAppConfiguration();
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

        public static MauiAppBuilder ConfigureAppConfiguration(this MauiAppBuilder app)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var baseNamespace = assembly.GetName().Name;

            // Adjust the namespace and file names as needed.
            string baseAppSettingsResource = $"{baseNamespace}.appsettings.json";
            string devAppSettingsResource = $"{baseNamespace}.appsettings.Development.json";

            // Add the base appsettings.json
            using (var stream = assembly.GetManifestResourceStream(baseAppSettingsResource))
            {
                if (stream != null)
                {
                    app.Configuration.AddJsonStream(stream);
                }
            }

#if DEBUG
            // Add the development appsettings if in DEBUG mode.
            using (var stream = assembly.GetManifestResourceStream(devAppSettingsResource))
            {
                if (stream != null)
                {
                    app.Configuration.AddJsonStream(stream);
                }
            }
#endif

            return app;
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder app)
        {
            //Add all you Services here

            app.Services.AddSingleton<INavigationService, NavigationService>();
            app.Services.AddSingleton<ISettingsService, SettingsService>();
            app.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
            app.Services.AddSingleton<IAzureOCRService, AzureOCRService>();

            return app;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder app)
        {
            //Add all your ViewModels here

            app.Services.AddSingleton<LoginViewModel>();
            app.Services.AddSingleton<ProjectViewModel>();
            app.Services.AddSingleton<ExpenseViewModel>();

            //Normally detail pages view models should be transient, it always depends on what you want the Injection to look like for your ViewModel
            app.Services.AddTransient<ProjectDetailViewModel>();
            app.Services.AddTransient<ExpenseDetailViewModel>();
            app.Services.AddTransient<NewExpenseViewModel>();

            return app;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder app)
        {
            //Add all your Views here - All Views should be Transient.

            app.Services.AddTransient<LoginView>();
            app.Services.AddTransient<ProjectsView>();
            app.Services.AddTransient<ProjectDetailView>();
            app.Services.AddTransient<ExpenseView>();
            app.Services.AddTransient<ExpenseDetailView>();
            app.Services.AddTransient<NewExpenseView>();

            return app;
        }
    }
}
