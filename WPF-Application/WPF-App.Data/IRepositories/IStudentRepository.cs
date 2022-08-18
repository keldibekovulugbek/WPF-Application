using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Domain.Entities.Users;

namespace WPF_App.Data.IRepositories
{
    public interface IStudentRepository
    {
        Task<IQueryable<Student>> GetAllAsync(Expression<Func<Student, bool>> predicate = null);

        Task<Student> GetAsync(Expression<Func<Student, bool>> predicate);

        Task<Student> AddAsync(Student entity);

        Task<Student> UpdateAsync(Student entity);

        Task<bool> DeleteAsync(int id);

        Task SaveAsync();
    }
}
