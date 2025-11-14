using System.Net.Http;
using LifeManagementApp.Interfaces;
using LifeManagementApp.Services;
using LifeManagementApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace LifeManagementApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // One shared HttpClient instance for the whole app
            builder.Services.AddSingleton<HttpClient>();

            // Joke service that uses HttpClient
            builder.Services.AddSingleton<IJokeService, JokeApiService>();

            // Register ViewModel + MainPage for DI
            builder.Services.AddSingleton<NotesViewModel>();
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}
