using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TodoManagement.Models;
using TodoManagement.Data;
using SQLite;
//using Xamarin.KotlinX.Coroutines.Channels;

namespace TodoManagement.ViewModels
{
	public partial class UsersViewModel : ObservableObject
	{
		private readonly DatabaseContext _context;

		public UsersViewModel(DatabaseContext context)
		{
			_context = context;
		}

		[ObservableProperty]
		private ObservableCollection<User> _users = new();

		[ObservableProperty]
		private User _operatingUsers = new();

		[ObservableProperty]
		private bool _isBusy;

		[ObservableProperty]
		private string _busyText;

        public async Task LoadUserAsync()
        {
            await ExecuteAsync(async () =>
            {
                var users = await _context.GetAllAsync<User>();
                if (users is not null && users.Any())
                {
                    Users ??= new ObservableCollection<User>();

                    foreach (var user in users)
                    {
                        Users.Add(user);
                    }
                }
            }, "Fetching user...");
        }

        [RelayCommand]
		private void SetOperatingUser(User? users) => OperatingUsers = users ?? new();

		[RelayCommand]
		private async Task SaveUserAsync()
		{
			if (OperatingUsers is null)
			{
				return;
			}

			var (isValid, errorMessage) = OperatingUsers.Validate();
			if (!isValid)
			{
				await Shell.Current.DisplayAlert("Validation Error", errorMessage, "Ok");
				return;
			}

			var busyText = OperatingUsers.Id == 0 ? "Creating user account..." : "Updating user";
			await ExecuteAsync(async () =>
			{
				if (OperatingUsers.Id == 0)
				{
					await _context.AddItemAsync<User>(OperatingUsers);
					Users.Add(OperatingUsers);
				}
                else
                {
                    //Update User Account 
                    if (await _context.UpdateItemAsync<User>(OperatingUsers))
                    {
                        var UserCopy = OperatingUsers.Clone();

                        var index = Users.IndexOf(OperatingUsers);
                        Users.RemoveAt(index);

                        Users.Insert(index, UserCopy);
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "User updation error", "Ok");
                        return;
                    }
                }
                SetOperatingUserCommand.Execute(new());
            }, busyText);
        }

        [RelayCommand]
        private async Task DeleteUserAsync(int id)
        {
            await ExecuteAsync(async () =>
            {
                if (await _context.DeleteItemByKeyAsync<User>(id))
                {
                    var user = Users.FirstOrDefault(p => p.Id == id);
                    Users.Remove(user);
                }
                else
                {
                    await Shell.Current.DisplayAlert("Delete Error", "User was not deleted", "Ok");
                }
            }, "Deleting User...");
        }

        private async Task ExecuteAsync(Func<Task> operation, string? busyText = null)
        {
            IsBusy = true;
            BusyText = busyText ?? "Processing...";
            try
            {
                await operation?.Invoke();
            }
            catch (Exception ex)
            {
                /*
                 * {System.TypeInitializationException: The type initializer for 'SQLite.SQLiteConnection' threw an exception.
                 ---> System.IO.FileNotFoundException: Could not load file or assembly 'SQLitePCLRaw.provider.dynamic_cdecl, Version=2.0.4.976, Culture=neutral, PublicKeyToken=b68184102cba0b3b' or one of its dependencies.
                File name: 'SQLitePCLRaw.provider.dynamic_cdecl, Version=2.0.4.976, Culture=neutral, PublicKeyToken=b68184102cba0b3b'
                   at SQLitePCL.Batteries_V2.Init()
                   at SQLite.SQLiteConnection..cctor()
                   --- End of inner exception stack trace ---
                   at SQLite.SQLiteConnectionWithLock..ctor(SQLiteConnectionString connectionString)
                   at SQLite.SQLiteConnectionPool.Entry..ctor(SQLiteConnectionString connectionString)
                   at SQLite.SQLiteConnectionPool.GetConnectionAndTransactionLock(SQLiteConnectionString connectionString, Object& transactionLock)
                   at SQLite.SQLiteConnectionPool.GetConnection(SQLiteConnectionString connectionString)
                   at SQLite.SQLiteAsyncConnection.GetConnection()
                   at SQLite.SQLiteAsyncConnection.<>c__DisplayClass33_0`1[[SQLite.CreateTableResult, SQLite-net, Version=1.8.116.0, Culture=neutral, PublicKeyToken=null]].<WriteAsync>b__0()
                   at System.Threading.Tasks.Task`1[[SQLite.CreateTableResult, SQLite-net, Version=1.8.116.0, Culture=neutral, PublicKeyToken=null]].InnerInvoke()
                   at System.Threading.Tasks.Task.<>c.<.cctor>b__273_0(Object obj)
                   at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
                --- End of stack trace from previous location ---
                   at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
                   at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot, Thread threadPoolThread)
                --- End of stack trace from previous location ---
                   at MAUISql.Data.DatabaseContext.<CreateTableIfNotExists>d__6`1[[MAUISql.Models.Product, MAUISql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]].MoveNext() in D:\MAUI\MAUISql\MAUISql\Data\DatabaseContext.cs:line 18
                   at MAUISql.Data.DatabaseContext.<GetTableAsync>d__7`1[[MAUISql.Models.Product, MAUISql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]].MoveNext() in D:\MAUI\MAUISql\MAUISql\Data\DatabaseContext.cs:line 23
                   at MAUISql.Data.DatabaseContext.<GetAllAsync>d__8`1[[MAUISql.Models.Product, MAUISql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]].MoveNext() in D:\MAUI\MAUISql\MAUISql\Data\DatabaseContext.cs:line 29
                   at MAUISql.ViewModels.ProductsViewModel.<LoadProductsAsync>b__6_0() in D:\MAUI\MAUISql\MAUISql\ViewModels\ProductsViewModel.cs:line 34
                   at MAUISql.ViewModels.ProductsViewModel.ExecuteAsync(Func`1 operation, String busyText) in D:\MAUI\MAUISql\MAUISql\ViewModels\ProductsViewModel.cs:line 103}
                 */
            }
            finally
            {
                IsBusy = false;
                BusyText = "Processing...";
            }
        }
    }
}

