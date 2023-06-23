using SQLite;
using TodoApp.Models;
using System.Collections.Generic;

namespace TodoApp;

public partial class RegistrationPage : ContentPage
{
    public RegistrationPage()
    {
        InitializeComponent();
    }

    public async void OnAddClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        await App.UserRepo.AddNewPerson(UserNameEntry.Text);
        statusMessage.Text = App.UserRepo.StatusMessage;
    }

    public async void OnGetClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        List<Users> user = await App.UserRepo.GetAllUser();
        userList.ItemsSource = user;
    }
}
