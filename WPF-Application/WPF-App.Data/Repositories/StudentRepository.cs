using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Data.Contexts;
using WPF_App.Data.IRepositories;
using WPF_App.Domain.Entities.Users;

namespace WPF_App.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {

        private readonly WPF_ApplicationDbContext dbContext;
        protected readonly DbSet<Student> dbSet;

        public StudentRepository()
        {
            dbContext = new WPF_ApplicationDbContext();
            dbSet = dbContext.Set<Student>();
        }

        public async Task<Student> AddAsync(Student entity)
            => (await dbSet.AddAsync(entity)).Entity;

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetAsync(s => s.Id == id);

            if (entity == null)
                return false;

            dbSet.Remove(entity);
            return true;
        }

        public async Task<IQueryable<Student>> GetAllAsync(Expression<Func<Student, bool>> predicate = null)
            => predicate is null ? dbSet : dbSet.Where(predicate);

        public Task<Student> GetAsync(Expression<Func<Student, bool>> predicate)
            => dbSet.FirstOrDefaultAsync(predicate);

        public async Task<Student> UpdateAsync(Student entity)
            => dbSet.Update(entity).Entity;

        public Task SaveAsync() => dbContext.SaveChangesAsync();
    }
}

