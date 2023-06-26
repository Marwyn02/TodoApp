//using System;
//using TodoManagement.Models;
//using SQLite;

//namespace TodoManagement.Models
//{
//	[Table("Tasks")]
//	public class Task
//	{
//		[PrimaryKey, AutoIncrement]
//		public int TaskId { get; set; }

//		[MaxLength(100)]
//		public string Title { get; set; }

//		[MaxLength(250)]
//		public string Description { get; set; }

//		public DateTime DueDate { get; set; }

//		public bool IsCompleted { get; set; }

		//[ForeignKey(typeof(User))]
		//public int UserId { get; set; }

		//[Ignore]
		//public User User { get; set; }
//	}
//}

