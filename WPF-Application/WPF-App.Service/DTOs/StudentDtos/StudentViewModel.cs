using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Service.DTOs.AttachmentDtos;

namespace WPF_App.Service.DTOs.StudentDtos
{
    public class StudentViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public AttachmentViewModel Image { get; set; }
        public AttachmentViewModel Passport { get; set; }

    }
}
