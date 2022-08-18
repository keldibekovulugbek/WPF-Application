using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Domain.Entities.Users;
using WPF_App.Service.DTOs.StudentDtos;

namespace WPF_App.Service.Interfaces
{
    public interface IStudentService
    {
        Task<StudentViewModel> CreateAsync(StudentViewModel entity);
        Task<StudentViewModel> UpdateAsync(StudentViewModel entity);
        Task<StudentViewModel> GetAsync(Expression<Func<Student, bool>> expression);
        Task<IEnumerable<StudentViewModel>> GetAllAsync(Expression<Func<Student, bool>> expression = null, Tuple<int, int> pagination = null);
        Task<bool> DeleteAsync(Expression<Func<Student, bool>> expression);
    }
}
