using System;
using MauiBlazorAuth0App.Models;

namespace MauiBlazorAuth0App.Services
{
	public interface ITodoService
	{
		Task<List<TodoModel>> GetAllTodo();

        Task<TodoModel> GetTodoById(int TodoId);

        Task<int> AddTodo(TodoModel todoModel);

		Task<int> UpdateTodo(TodoModel todoModel);

		Task<int> DeleteTodo(TodoModel todoModel);
	}
}

