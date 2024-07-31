using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApplication.Domain.Models;
using TimeTrackingApplication.Domain.Repositories;
using TimeTrackingApplication.Repository.DBContext;

namespace TimeTrackingApplication.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TimeTrackingApplicationDBContext dbContext) : base(dbContext)
        {
        }

        public bool ValidateUser(string userName, string password)
        {
            var user = context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            if (user == null) return false;
            else return true;
        }
        public User GetByUserNameAndPassword(string userName, string password)
        {
            return context.Users.First(u => u.UserName== userName && u.Password == password);
        }
    }
}
