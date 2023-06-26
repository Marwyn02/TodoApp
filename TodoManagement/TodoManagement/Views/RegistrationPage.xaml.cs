using TodoManagement.Services;
using TodoManagement.ViewModels;

namespace TodoManagement.Views;

public partial class RegistrationPage : ContentPage
{
    private readonly AuthService _authService;
    private readonly UsersViewModel _viewModel;

    public RegistrationPage(AuthService authService, UsersViewModel viewModel)
	{
		InitializeComponent();
        _authService = authService;
		BindingContext = viewModel;
		_viewModel = viewModel;
    }

	private async void Button_Clicked(object sender, EventArgs e)
	{
		_authService.Login();
		await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
	}

    void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
    }
}
