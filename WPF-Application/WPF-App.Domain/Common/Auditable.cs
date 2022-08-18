using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App.Domain.Common
{
    public abstract class Auditable
    {
        public long Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public void Create()
            =>CreateAt=DateTime.UtcNow;

        public void Update()
            =>UpdateAt=DateTime.UtcNow;
    }
}
