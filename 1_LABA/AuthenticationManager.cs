using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_LABA
{
    public class AuthenticationManager
    {
        private const string AdminPasswordHash = "C93CCD78B2076528346216B3B2F701E6";
        public event Action LoggedIn;

        public bool IsAdmin
        {
            get { return AuthenticatedUser == KnownUsers.Admin; }
        }

        public string AuthenticatedUser { get; private set; }

        public void Login(string login, string password)
        {
            var passwordHash = CreateMD5(login + password);

            if (login == KnownUsers.Admin)
            {
                if (passwordHash == AdminPasswordHash)
                {
                    AuthenticatedUser = login;
                    LoggedIn?.Invoke();
                }
                else
                {
                    throw new Exception("Password is not correct");
                }
            }
            else
            {
                AuthenticatedUser = login;
                LoggedIn?.Invoke();
            }
        }

        private static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }
    }
}