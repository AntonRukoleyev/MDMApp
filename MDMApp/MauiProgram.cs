using Microsoft.Maui.Hosting;

namespace MDMApp
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

            // Регистрация сервиса для Android
#if ANDROID
            builder.Services.AddSingleton<ICameraService, MDMApp.CameraService>();
#endif

            // Регистрация сервиса для iOS


            return builder.Build();
        }
    }
}
