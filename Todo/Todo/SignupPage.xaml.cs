using Todo.Models;
using System.Collections.Generic;

namespace Todo;

public partial class SignupPage : ContentPage
{
	public SignupPage()
	{
		InitializeComponent();
	}

	public void AddNewUserButton(object sender, EventArgs args)
	{
		statusMessage.Text = "";

		App.UserRepo.AddNewUser(newFirstName.Text, newLastName.Text, newEmail.Text, newPassword.Text);
		statusMessage.Text = App.UserRepo.StatusMessage;
	}

	public void GetAllUserButton(object sender, EventArgs args)
	{
		statusMessage.Text = "";

		List<Users> user = App.UserRepo.GetUsers();
		userList.ItemsSource = user;
	}
}