using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Data.IRepositories;
using WPF_App.Domain.Entities.Users;

namespace WPF_App.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
       
    }
}
