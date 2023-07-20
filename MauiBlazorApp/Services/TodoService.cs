using System;
using SQLite;
using MauiBlazorAuth0App.Models;

namespace MauiBlazorAuth0App.Services
{
    public class TodoService : ITodoService
    {
        private SQLiteAsyncConnection _dbConnection;

        public TodoService()
        {
            SetUpDb();
        }

        private async void SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Todo.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<TodoModel>();
            }
        }

        public async Task<int> AddTodo(TodoModel todoModel)
        {
            return await _dbConnection.InsertAsync(todoModel);
        }

        public async Task<int> DeleteTodo(TodoModel todoModel)
        {
            return await _dbConnection.DeleteAsync(todoModel);
        }

        public async Task<int> UpdateTodo(TodoModel todoModel)
        {
            return await _dbConnection.UpdateAsync(todoModel);
        }

        public async Task<List<TodoModel>> GetAllTodo()
        {
            return await _dbConnection.Table<TodoModel>().OrderByDescending(x => x.Due).ToListAsync();
        }

        public async Task<TodoModel> GetTodoById(int TodoId)
        {
            var todo = await _dbConnection.QueryAsync<TodoModel>($"Select * From {nameof(TodoModel)} where TodoId={TodoId}" );
            return todo.FirstOrDefault();
        }
    }
}
