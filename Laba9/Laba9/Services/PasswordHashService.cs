﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Laba9.Services
{
    public class PasswordHashService
    {
        public string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }

        public bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            byte[] hash = new byte[20];
            Array.Copy(hashBytes, 16, hash, 0, 20);

            var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, 10000);
            byte[] inputHash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hash[i] != inputHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
