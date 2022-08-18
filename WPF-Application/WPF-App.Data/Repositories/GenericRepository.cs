using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Data.IRepositories;

namespace WPF_App.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
