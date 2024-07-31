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
    public class BaseRepository<T>: IBaseRepository<T> where T : BaseEntity
    {
        protected readonly TimeTrackingApplicationDBContext context;
        public BaseRepository(TimeTrackingApplicationDBContext dbContext)
        {
            context = dbContext;
        }
        public T GetById(Guid id)
        {
            return context.Set<T>().First(u => u.Id == id);
        }
        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var entity = context.Set<T>().First(u => u.Id == id);
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}
