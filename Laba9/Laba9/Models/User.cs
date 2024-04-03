using System;
using System.ComponentModel.DataAnnotations;

namespace Laba9.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(15)]
        public string FirstName { get; set; }

        [MaxLength(15)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Password { get; set; }

        public DateTime LastLoginDate { get; set; }

        public int LoginAttempts { get; set; }
    }
}
