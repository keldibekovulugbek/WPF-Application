using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Data.IRepositories;
using WPF_App.Domain.Entities.Users;
using WPF_App.Service.DTOs.StudentDtos;
using WPF_App.Service.Interfaces;

namespace WPF_App.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly TypeAdapterConfig config;

        public StudentService()
        {
            StudentRepository = new StudentRepository();
            adressRepository = new AdressRepository();

            config = new TypeAdapterConfig();
            config.NewConfig<Student, StudentViewModel>()
                .Map(dest => dest.Orders, src => src.Orders.Select(x => x.Adapt<OrderViewModel>()))
                .Map(dest => dest.Adress, src => src.Adress);

        }
        public async Task<StudentViewModel> CreateAsync(StudentViewModel Student)
        {
            var exist = await StudentRepository.GetAsync(u => u.StudentName.ToLower().Equals(Student.StudentName.ToLower()));
            var existAdress = adressRepository.GetAsync(a => a.Id == Student.AdressId);

            if (exist is not null)
                throw new Exception("Student already exist");

            if (existAdress is null)
                throw new Exception("Adress not found");

            var returnedStudent = await StudentRepository.AddAsync(new Student()
            {
               
            });
            await StudentRepository.SaveAsync();

            return (await StudentRepository.GetAsync(u => u.Id == returnedStudent.Id)).Adapt<StudentViewModel>();
        }

        public async Task<bool> DeleteAsync(Expression<Func<Student, bool>> predicate)
        {
            var result = await StudentRepository.DeleteAsync(predicate);
            await StudentRepository.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<StudentViewModel>> GetAllAsync(Expression<Func<Student, bool>> predicate = null, Tuple<int, int> pagination = null)
            => (await StudentRepository.GetAllAsync(predicate)).GetPagination(pagination)
                    .Adapt<IEnumerable<StudentViewModel>>();

        public async Task<StudentViewModel> GetAsync(Expression<Func<Student, bool>> predicate)
            => (await StudentRepository.GetAllAsync(predicate)).Include(u => u.Adress)
                                                             .Include(u => u.Orders)
                                                             .FirstOrDefaultAsync().Adapt<StudentViewModel>(config);

        public async Task<StudentViewModel> LoginAsync(StudentForLogin Student)
            => (await StudentRepository.GetAsync(u => u.Email.Equals(Student.Email)
                                && u.Password.Equals(Student.Password.Encode()))).Adapt<StudentViewModel>();

        public async Task<StudentViewModel> UpdateAsync(StudentViewModel Student)
        {
            var exist = await StudentRepository.GetAsync(u => u.Email.Equals(Student.Email));
            var existStudent = await StudentRepository.GetAsync(u => u.StudentName.Equals(Student.StudentName));
            var existAdress = await adressRepository.GetAsync(a => a.Id == Student.AdressId);

            if (exist is null)
                throw new Exception("Student not found");

            if (existStudent is not null)
                throw new Exception("Student already exist");

            if (existAdress is null)
                throw new Exception("Address not found");

            exist.FullName = Student.FullName;
            exist.StudentName = Student.StudentName;
            exist.AdressId = Student.AdressId;
            exist.Email = Student.Email;
            exist.Password = Student.Password.Encode();
            exist.PhoneNumber = Student.PhoneNumber;
            exist.UpdatedAt = DateTime.UtcNow;

            var updated = await StudentRepository.UpdateAsync(exist);
            await StudentRepository.SaveAsync();

            return updated.Adapt<StudentViewModel>();
        }
}
