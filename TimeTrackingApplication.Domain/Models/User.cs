using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TimeTrackingApplication.Domain.Models
{
    public class User: BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public User(string userName, string password)
        {
            ValidateUserName(userName);
            ValidatePassword(password);
        }

        public User() 
        {

        }

        private void ValidateUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException("User Name is null or empty.");
            UserName = userName;
        }

        private void ValidatePassword(string password)
        {
            //password has at least one upper, one lower and one number
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$";

            if (!Regex.IsMatch(password, pattern)) throw new ArgumentException("Password is not valid.");
            Password = password;
        }
    }
}
