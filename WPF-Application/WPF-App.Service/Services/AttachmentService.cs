using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Data.IRepositories;
using WPF_App.Data.Repositories;
using WPF_App.Domain.Entities.Attachments;
using WPF_App.Domain.Entities.Users;
using WPF_App.Service.DTOs.AttachmentDtos;
using WPF_App.Service.DTOs.StudentDtos;
using WPF_App.Service.Interfaces;

namespace WPF_App.Service.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly TypeAdapterConfig config;

        public AttachmentService()
        {

            studentRepository = new StudentRepository();

            config = new TypeAdapterConfig();
            config.NewConfig<Student, StudentViewModel>()
                .Map(dest => dest.Image, src => src.Image)
                .Map(dest => dest.Passport, src => src.Passport);

        }
        public Task<AttachmentViewModel> CreateAsync(AttachmentViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<Attachment, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AttachmentViewModel>> GetAllAsync(Expression<Func<Attachment, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            throw new NotImplementedException();
        }

        public Task<AttachmentViewModel> GetAsync(Expression<Func<Attachment, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<AttachmentViewModel> UpdateAsync(AttachmentViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
