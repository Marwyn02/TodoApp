using Microsoft.Extensions.Logging;
using TodoManagement.Services;
using TodoManagement.Views;
using TodoManagement.ViewModels;
using TodoManagement.Data;

namespace TodoManagement;

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
        builder.Services.AddSingleton<DatabaseContext>();
        builder.Services.AddSingleton<UsersViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<AuthService>();
        builder.Services.AddTransient<LoadingPage>();
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<RegistrationPage>();
        //builder.Services.AddTransient<MainPage>();

        return builder.Build();
	}
}

