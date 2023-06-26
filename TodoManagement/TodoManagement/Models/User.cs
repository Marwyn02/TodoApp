using System;
using SQLite;

namespace TodoManagement.Models
{
	public class User
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }

		public User Clone() => MemberwiseClone() as User;

		public (bool IsValid, string? ErrorMessage) Validate()
		{
			if (string.IsNullOrWhiteSpace(Name))
			{
				return (false, $"{nameof(Name)} is required.");
			}
			else if(string.IsNullOrWhiteSpace(Password))
			{
				return (false, $"{nameof(Password)} is required.");
			}
			return (true, null);
		}
	}
}

