using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.DataAccess.Repositories.Abstractions
{
    public interface IRepository<T> where T : class
    {
        public Task <T?> getByID(int id);
        public Task deleteByID(int id);
        public Task add(T entity);
        public Task update(T entity);
    }
}
