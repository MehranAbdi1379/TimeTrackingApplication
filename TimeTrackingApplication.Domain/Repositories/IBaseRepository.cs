using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApplication.Domain.Models;

namespace TimeTrackingApplication.Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public T GetById(Guid id);
        public List<T> GetAll();
        public void Add(T entity);
        public void Delete(Guid id);
        public void Update(T entity);
    }
}
