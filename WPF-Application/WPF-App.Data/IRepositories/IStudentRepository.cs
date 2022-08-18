using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Domain.Entities.Users;

namespace WPF_App.Data.IRepositories
{
    public interface IStudentRepository: IGenericRepository<Student>
    {
    }
}
