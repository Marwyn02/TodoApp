using TodoManagement.ViewModels;

namespace TodoManagement.Views;

public partial class MainPage : ContentPage
{

	private readonly UsersViewModel _viewModel;
	private bool isDataLoaded = false;

	public MainPage(UsersViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_viewModel = viewModel;
		
	}

	protected async override void OnAppearing()
	{
        base.OnAppearing();

        if (!isDataLoaded)
		{
            await _viewModel.LoadUserAsync();
            isDataLoaded = true;
		}
	}
}