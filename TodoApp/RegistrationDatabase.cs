using System;
using SQLite;
using TodoApp.Models;

namespace TodoApp
{


    //public class RegistrationDatabase
    //{
    //    SQLiteAsyncConnection Database;

    //    public RegistrationDatabase()
    //    {
    //    }

    //    async Task Init()
    //    {
    //        if (Database is not null)
    //            return;

    //        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
    //        var result = await Database.CreateTableAsync<RegisteredUsers>();
    //    }

    //public async Task<List<RegisteredUsers>> GetItemsAsync()
    //        {
    //            await Init();
    //            return await Database.Table<RegisteredUsers>().ToListAsync();
    //        }

    //        public async Task<List<RegisteredUsers>> GetItemsNotDoneAsync()
    //        {
    //            await Init();
    //            return await Database.Table<TodoItem>().Where(t => t.Done).ToListAsync();

    //            // SQL queries are also possible
    //            //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
    //        }

    //        public async Task<RegisteredUsers> GetItemAsync(int id)
    //        {
    //            await Init();
    //            return await Database.Table<RegisteredUsers>().Where(i => i.ID == id).FirstOrDefaultAsync();
    //        }

    //        public async Task<int> DeleteItemAsync(TodoItem item)
    //        {
    //            await Init();
    //            return await Database.DeleteAsync(item);
    //        }
    //    }
    //}

    class Users
    {
        public string UserName { get; internal set; }
    }
}

