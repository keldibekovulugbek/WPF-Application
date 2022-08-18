using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Data.IRepositories;
using WPF_App.Data.Repositories;
using WPF_App.Domain.Entities.Users;
using WPF_App.Service.DTOs.StudentDtos;
using WPF_App.Service.Extensions;
using WPF_App.Service.Interfaces;

namespace WPF_App.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly TypeAdapterConfig config;

        public StudentService()
        {

            studentRepository = new StudentRepository();

            config = new TypeAdapterConfig();
            config.NewConfig<Student, StudentViewModel>()
                .Map(dest => dest.Image, src => src.Image)
                .Map(dest => dest.Passport, src => src.Passport);

        }

        public async Task<StudentViewModel> CreateAsync(StudentViewModel Student)
        {
            if (Student.FirstName is null || Student.LastName is null || Student.Faculty == null)
                throw new Exception();

            var student = Student.Adapt<Student>();
            var entity = await studentRepository.AddAsync(student);
            student.Create();
            await studentRepository.SaveAsync();

            return student.Adapt<StudentViewModel>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await studentRepository.DeleteAsync(id);
            await studentRepository.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<StudentViewModel>> GetAllAsync(Expression<Func<Student, bool>> predicate = null, Tuple<int, int> pagination = null)
            => (await studentRepository.GetAllAsync(predicate)).GetPagination(pagination)
                    .Adapt<IEnumerable<StudentViewModel>>(config);

        public async Task<StudentViewModel> GetAsync(Expression<Func<Student, bool>> predicate)
            => (await studentRepository.GetAllAsync(predicate)).Include(u => u.Image)
                                                             .Include(u => u.Passport)
                                                             .FirstOrDefaultAsync().Adapt<StudentViewModel>(config);

        public async Task<StudentViewModel> UpdateAsync(StudentViewModel Student)
        {
            if (Student.FirstName is null || Student.LastName is null || Student.Faculty == null)
                throw new Exception();

            var student = Student.Adapt<Student>();
            var entity = await studentRepository.UpdateAsync(student);
            student.Update();

            await studentRepository.SaveAsync();

            return student.Adapt<StudentViewModel>();
        }
    }
}
