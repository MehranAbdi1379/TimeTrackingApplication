using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackingApplication.ConsoleUI.Services
{
    public static class OutputService
    {
        public static int AskForSignUpOrSignIn()
        {
            Console.WriteLine("Sign in (1) or Sign up (2) ?");
            var done = int.TryParse(Console.ReadLine(), out var input);
            while(!done)
            {
                Console.WriteLine("Sign in (1) or Sign up (2) ?");
                done = int.TryParse(Console.ReadLine(),out input);
            }
            return input;
        }
        public static (string userName, string password) AskForUserNameAndPassword()
        {
            Console.Write("Please enter username: ");
            var userName = Console.ReadLine();

            Console.Write("Please enter password: ");
            var password = Console.ReadLine();

            return (userName, password);
        }
    }
}
