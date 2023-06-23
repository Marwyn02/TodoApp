using System;
using SQLite;

namespace TodoApp.Models
{
    [Table("user")]
	public class Users
	{
        [Column("id")]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("username")]
        [MaxLength(250), Unique]
        public string UserName { get; set; }
    }
}

