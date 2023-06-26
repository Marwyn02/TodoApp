using TodoManagement.Services;

namespace TodoManagement.Views;

public partial class ProfilePage : ContentPage
{
    private readonly AuthService _authService;

    public ProfilePage(AuthService authService)
	{
		InitializeComponent();
        _authService = authService;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        _authService.Logout();
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}
