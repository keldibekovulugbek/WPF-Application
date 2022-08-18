using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_App.Domain.Common;
using WPF_App.Domain.Entities.Attachments;

namespace WPF_App.Domain.Entities.Users
{
    public class Student : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public long? PassportId { get; set; }
        public long? ImageId { get; set; }
        public Attachment Passport { get; set; }
        public Attachment Image { get; set; }
    }
}
