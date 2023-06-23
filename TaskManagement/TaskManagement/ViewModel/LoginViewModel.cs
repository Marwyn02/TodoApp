using System;
using TaskManagement.Models;
using System.Windows.Input;

namespace TaskManagement.ViewModel
{
	public class LoginViewModel
	{
        private string _username, _password;

		public string Username { get => _username; set => _username = value; }

        public string Password { get => _password; set => _password = value; }

		public ICommand RegisterCommand { private set; get; }
        public ICommand LoginCommand { private set; get; }

		private INavigation Navigation;

        public LoginViewModel(INavigation navigation)
		{
			RegisterCommand = new Command(OnRegisterCommand);
			LoginCommand = new Command(OnLoginCommand);
			Navigation = navigation; 
		}

		private async void OnLoginCommand(object obj)
		{
			var loginData = await App.Database.GetLoginDataAsync(Username);

			if (loginData is not null)
			{
				if (string.Equals(loginData.Password, Password))
				{

				} else
				{
					await App.Current.MainPage.DisplayAlert("failure", "Invalid Password", "Ok");
				}
			}
			else
			{
				await App.Current.MainPage.DisplayAlert("failure", "Invalid Username", "Ok");
			}
		}

        private void OnRegisterCommand(object obj)
        {
			LoginModel lm = new LoginModel();
			lm.Username = Username;
			lm.Password = Password;
			App.Database.SaveLoginDataAsync(lm);
			App.Current.MainPage.DisplayAlert("Success", "Registration Successful", "Ok");
        }
    }
}

