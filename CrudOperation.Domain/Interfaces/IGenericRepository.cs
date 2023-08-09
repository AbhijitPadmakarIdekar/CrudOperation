using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperation.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> GetById(int id);
        public Task<IEnumerable<T>> GetAll();
        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        public Task Add(T entity);
        public Task AddRange(IEnumerable<T> entities);
        public void Remove(T entity);
        public void RemoveRange(IEnumerable<T> entities);
    }
}