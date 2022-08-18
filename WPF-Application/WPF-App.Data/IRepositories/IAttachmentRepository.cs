using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Domain.Common;
using WPF_App.Domain.Entities.Attachments;

namespace WPF_App.Data.IRepositories
{
    public interface IAttachmentRepository 
    {
        Task<IQueryable<Attachment>> GetAllAsync(Expression<Func<Attachment, bool>> predicate = null);

        Task<Attachment> GetAsync(Expression<Func<Attachment, bool>> predicate);

        Task<Attachment> AddAsync(Attachment entity);

        Task<Attachment> UpdateAsync(Attachment entity);

        Task<bool> DeleteAsync(Expression<Func<Attachment, bool>> predicate);

        Task SaveAsync();
    }
}
