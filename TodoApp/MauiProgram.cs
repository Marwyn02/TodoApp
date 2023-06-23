using Microsoft.Extensions.Logging;
using TodoApp;

namespace TodoApp
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

            //string dbPath = FileAccessHelper.GetLocalFilePath("usersDB.sqlite3");
            builder.Logging.AddDebug();

            //builder.Services.AddSingleton<UserRepository>(s => ActivatorUtilities.CreateInstance<UserRepository>(s, DbPath));
            builder.Services.AddSingleton<UserRepository>();


            return builder.Build();
        }
    }
}



