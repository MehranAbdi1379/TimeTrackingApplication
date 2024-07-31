using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApplication.Domain.Models;

namespace TimeTrackingApplication.Domain.Repositories
{
    public interface IUserRepository: IBaseRepository<User>
    {
        public bool ValidateUser(string userName, string password);
        public User GetByUserNameAndPassword(string userName, string password);
    }
}
