using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TimeTrackingApplication.ConsoleUI.Services;
using TimeTrackingApplication.Domain.Models;
using TimeTrackingApplication.Domain.Repositories;
using TimeTrackingApplication.Repository.DBContext;
using TimeTrackingApplication.Repository.Repositories;

namespace TimeTrackingApplication.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Services.Services.SetServiceProvider();

            // Use DbContext
            using (var context = serviceProvider.GetService<TimeTrackingApplicationDBContext>())
            {
                context.Database.EnsureCreated();


                StartAppliation(context);
            }
        }

        static void StartAppliation(TimeTrackingApplicationDBContext context)
        {
            var userRepository = new UserRepository(context);

            try
            {
                var signUpOrSignIn = OutputService.AskForSignUpOrSignIn();

                switch (signUpOrSignIn)
                {
                    case 1:
                        SignIn(userRepository);
                        break;
                    case 2:
                        SignUp();
                        break;
                    default:
                        StartAppliation(context);
                        break;
                }

                var (userName, password) = OutputService.AskForUserNameAndPassword();

                var user = userRepository.GetByUserNameAndPassword(userName, password);

                Console.Write($"{user.Id}:{user.UserName}:{user.Password}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                StartAppliation(context);
            }
        }
        static void SignUp(IUserRepository userRepository)
        {
            var (userName, password) = OutputService.AskForUserNameAndPassword();

            var user = new User(userName, password);

            userRepository.Add(user);

        }
        static void SignIn(IUserRepository userRepository)
        {
            var (userName, password) = OutputService.AskForUserNameAndPassword();

            var user = userRepository.GetByUserNameAndPassword(userName, password);

            Console.Write($"{user.Id}:{user.UserName}:{user.Password}");
        }
    }
}
