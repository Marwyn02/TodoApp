using System;
using SQLite;
namespace MauiBlazorAuth0App.Models
{
	public class TodoModel
	{
		[PrimaryKey, AutoIncrement]
		public int TodoId { get; set; }

		public string Title { get; set; }

		public DateTime Due { get; set; } 

		public bool IsCompleted { get; set; }
	}
}

