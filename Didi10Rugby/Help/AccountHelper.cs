using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Didi10Rugby.Help
{
    public class AccountHelper
    {
        public static string AuthSecret = "204772A72B733B48594A79186532271A96DD325427F5AF990EA7FFFE9AEC026F";
        private static Random random = new Random();

        //Generate RandomNo
        public int GenerateRandomNo()
        {
            Random _rdm = new Random();
            int _min = 1000;
            int _max = 10000;
            return _rdm.Next(_min, _max);
        }
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 32)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string GetHash256ByString(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}