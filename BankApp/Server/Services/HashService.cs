using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace BankApp.Server.Services
{
    public static class HashService
    {
        public static string HashString(string stringToHash)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(stringToHash, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string hashString = Convert.ToBase64String(hashBytes);
            return hashString;
        }

        public static bool CompareStringToHashString(string comparedString, string hashString)
        {
            byte[] hashBytes = Convert.FromBase64String(hashString);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(comparedString, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            return true;
        }
    }
}