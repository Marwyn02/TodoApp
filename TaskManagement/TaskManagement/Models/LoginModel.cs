using System;
using SQLite;

namespace TaskManagement.Models
{
	public class LoginModel
	{
		[PrimaryKey]
		public string Username { get; set; }

		public string Password { get; set; }
	}
}

