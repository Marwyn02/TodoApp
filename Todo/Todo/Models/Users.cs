using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Todo.Models
{
    [Table("user")]
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(250), Unique]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }
    }
}
