using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WPF_App.Domain.Entities.Attachments;
using WPF_App.Domain.Entities.Users;

namespace WPF_App.Data.Contexts
{
    public class WPF_ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Host=localhost;Port=5432;Database=WPF-Application;Username=postgres;Password=12042003";
            optionsBuilder.UseNpgsql(connectionString);
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }

    }
}
