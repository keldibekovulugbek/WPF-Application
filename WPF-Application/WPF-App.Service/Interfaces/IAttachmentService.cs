using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Domain.Entities.Attachments;
using WPF_App.Service.DTOs.AttachmentDtos;

namespace WPF_App.Service.Interfaces
{
    public interface IAttachmentService
    {
        Task<AttachmentViewModel> CreateAsync(AttachmentViewModel entity);
        Task<AttachmentViewModel> UpdateAsync(AttachmentViewModel entity);
        Task<AttachmentViewModel> GetAsync(Expression<Func<Attachment, bool>> expression);
        Task<IEnumerable<AttachmentViewModel>> GetAllAsync(Expression<Func<Attachment, bool>> expression = null, Tuple<int, int> pagination = null);
        Task<bool> DeleteAsync(Expression<Func<Attachment, bool>> expression);
    }
}
