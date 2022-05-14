using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject
{
    public class SchoolContext :DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=EntityFrameworkEXAM; Trusted_Connection=True");
        }
    }
}
