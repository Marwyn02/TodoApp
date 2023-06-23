using System;
using TaskManagement.Models;
using SQLite;

namespace TaskManagement.Database
{
	public class LoginDatabase
	{
		readonly SQLiteAsyncConnection database;

		public LoginDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<LoginModel>().Wait();
		}

		public Task<LoginModel> GetLoginDataAsync(string username)
		{
			return database.Table<LoginModel>().Where(i => i.Username == username).FirstOrDefaultAsync();
		}

        public Task<int> SaveLoginDataAsync(LoginModel logindata)
		{
			return database.InsertAsync(logindata);
		}

    }
}

