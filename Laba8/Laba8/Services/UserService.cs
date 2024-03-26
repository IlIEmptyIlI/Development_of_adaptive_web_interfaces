using System;
using System.Collections.Generic;
using System.Linq;
using Laba8.Models;

namespace Laba8.Services
{
    public class UserService
    {
        private static List<User> _users = new List<User>();

        public UserService()
        {
            InitializeUsers();
        }

        private void InitializeUsers()
        {
            // Ініціалізація тестових користувачів
            _users.Add(new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                Password = "hashedpassword1",
                LastLoginDate = DateTime.Now.AddDays(-1),
                LoginAttempts = 0
            });

            _users.Add(new User
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane@example.com",
                DateOfBirth = new DateTime(1995, 5, 5),
                Password = "hashedpassword2",
                LastLoginDate = DateTime.Now.AddDays(-2),
                LoginAttempts = 0
            });

            // Додати інші тестові записи
        }

        public User GetUserByEmail(string email)
        {
            return _users.Find(u => u.Email == email);
        }
        public List<User> GetAllUsers()
        {
            return _users;
        }


        public void AddUser(User user)
        {
            _users.Add(user);
        }

        // Додати інші методи, які можуть бути потрібні
    }
}
