using System;
using System.Collections.Generic;
using System.Linq;
// using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Todo.Models;
// using Windows.Devices.Sms;

namespace Todo
{
    public class UserRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Users>();
        }

        public UserRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewUser(string firstName, string lastName, string email, string password)
        {
            ArgumentNullException.ThrowIfNull(firstName, nameof(firstName));
            ArgumentNullException.ThrowIfNull(lastName, nameof(lastName));
            ArgumentNullException.ThrowIfNull(email, nameof(email));
            ArgumentNullException.ThrowIfNull(password, nameof(password));

            int result = 0;
            try
            {
                Init();

                result = conn.Insert(new Users {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Password = password
                });
                StatusMessage = string.Format("{0} record(s) added (Name: {1} {2}) (Email: {3}) (Password: {4})", result, firstName, lastName, email, password);
            } catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", firstName, ex.Message);
            }
        }

        public List<Users> GetUsers()
        {
            try
            {
                Init();

                return conn.Table<Users>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Users>();
        }
    }
}
