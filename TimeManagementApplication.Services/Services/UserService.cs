using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementApplication.Services.DTO;
using TimeTrackingApplication.Domain.Models;
using TimeTrackingApplication.Domain.Repositories;

namespace TimeManagementApplication.Services.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User ValidateUser(UserCreateDTO dto)
        {
            if(userRepository.ValidateUser(dto.UserName,dto.Password))
            {
                return userRepository.GetByUserNameAndPassword(dto.UserName,dto.Password);
            }
            throw new Exception("There is no user with this Username and Password.");
        }
        public void CreateNewUser(UserCreateDTO dto)
        {
            var user = new User(dto.UserName,dto.Password);
            userRepository.Add(user);
        }
        public void UpdateUser(UserUpdateDto dto)
        {
            var user = userRepository.GetById(dto.Id);
            user.UserName = dto.UserName;
            user.Password = dto.Password;
            userRepository.Update(user);
        }
        public void DeleteUser(IdDTO dto)
        {
            userRepository.Delete(dto.Id);
        }
    }
}
