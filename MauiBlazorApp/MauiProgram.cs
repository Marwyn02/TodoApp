using Microsoft.Extensions.Logging;
using MauiBlazorAuth0App.Data;
using MauiBlazorAuth0App.Services;
using Microsoft.AspNetCore.Components.Authorization;
using MauiBlazorAuth0App.Auth0;

namespace MauiBlazorAuth0App;

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
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Services.AddBlazorWebView();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<ITodoService, TodoService>();
		builder.Services.AddSingleton<WeatherForecastService>();

		builder.Services.AddSingleton(new Auth0Client(new()
    {
      Domain = "dev-psbqprzgncbc4nfy.us.auth0.com",
      ClientId = "0qMLRuOvY58H98zk82J2limKqnYsgbec",
	    Scope = "openid profile",
	    RedirectUri = "myapp://callback"
    }));
		builder.Services.AddAuthorizationCore();
		builder.Services.AddScoped<AuthenticationStateProvider, Auth0AuthenticationStateProvider>();

		return builder.Build();
	}
}
