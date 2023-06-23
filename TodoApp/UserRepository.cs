using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp
{
	public class UserRepository
	{
        string _dbPath;

        private const string DbName = "MyData.db3";
        private static string DbPath => Path.Combine(FileSystem.AppDataDirectory, DbName);

        public string StatusMessage { get; set; }

        private SQLiteAsyncConnection conn;
        private SQLiteAsyncConnection Database =>
            (conn ??= new SQLiteAsyncConnection(DbPath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadOnly | SQLiteOpenFlags.SharedCache));

        private async Task Init()
        {
            if (Database is not null)
            {
                return;
            }

            //Database = new SQLiteAsyncConnection(_dbPath);

            await Database.CreateTableAsync<Users>();
        }

        public UserRepository(string dbPath)
		{
            _dbPath = dbPath;
           
        }

        public async Task AddNewPerson(String name)
        {

            //ArgumentNullException.ThrowIfNull(name, nameof(name));

            int result = 0;
            try
            {
                await Init();

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = await Database.InsertAsync(new Users {UserName = name});

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }

        public async Task<List<Users>> GetAllUser()
        {
            try
            {
                await Init();

                return await Database.Table<Users>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add. Error {0}", ex.Message);
            }

            return new List<Users>();
        }
    }
}