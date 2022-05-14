using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject
{
    public class Course
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Departament> Departaments { get; set; } = new List<Departament>();
        // public List<Student> Students { get; set; } = new List<Student>();
    }
}
