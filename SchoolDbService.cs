using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject
{
    internal class SchoolDbService
    {
        // ---1--- +++
        public static void CreateDepartamentAndAddStudentsAndCourses(string departamentName, List<Student> studentList, List<Course> courseList)
        {
            using var db = new SchoolContext();
            Departament departament = new Departament()
            {
                Name = departamentName,
            };
            departament.Students = studentList;
            departament.Courses = courseList;
            db.Departaments.Add(departament);   
            db.SaveChanges();
        }

        // ---2--- +++
        public static void AddStudentsAndCoursesToEgsistingDepartament(int departamentId, List<Student> studentList, List<Course> courseList)
        {
            using var db = new SchoolContext();
            var dep = db.Departaments
                .Where(d => d.Id == departamentId)
                .Include(d => d.Courses)
                .Include(d => d.Students)
                .FirstOrDefault<Departament>();
            if(dep != null)
            {
                foreach (var student in studentList)
                {
                    dep.Students.Add(student);
                };
                foreach (var course in courseList)
                {
                    dep.Courses.Add(course);
                }; 
            }
            db.SaveChanges();
        }

        //---3--- +++
        public static void CreateCourseAndAddToExistingDepartament(string courseName, int departamentId)
        {
            using var db = new SchoolContext();
            var dep = db.Departaments
                .Where(d => d.Id == departamentId)
                .Include(d => d.Courses)
                .FirstOrDefault<Departament>();
            Course course = new Course() { Name = courseName };

            if (dep == null)
            {
                Console.WriteLine("There is no such departament");
            }
            else
            {
                dep.Courses.Add(course);
            }
            db.SaveChanges();
        }

        //---4--- +++

        public static void CreateStudentAndAddToEgsistingDepartament(string studentName, int departamentId)
        {
            using var db = new SchoolContext();
            var student = new Student() { Name = studentName, DepartamentId = departamentId };

            db.Students.Add(student);
            
            var dep = db.Departaments
                .Include(d => d.Students)
                .FirstOrDefault(d => d.Id == departamentId);
            
            dep.Students.Add(student);
            db.SaveChanges();
        }

        //---5--- +++
        public static void TransferStudentToOtherDepartament(int studentId, int departamentId)
        {
            using var db = new SchoolContext();
            var student = db.Students
                .Where(s => s.Id == studentId).
                Include(s => s.Departament)
                .SingleOrDefault<Student>();
            var departament = db.Departaments
                .Where(d => d.Id == departamentId)
                .Include(d => d.Courses)
                .SingleOrDefault<Departament>();
            if(student == null || departament == null)
            {
                Console.WriteLine("There is no such student or departament..");
            }
            else
            {
                student.Departament = departament;
                student.Courses = departament.Courses;
              //  db.Update(db.Students);
                db.SaveChanges();
            }
        }

        //---6--- +++
        public static void PrintAllStudentsOfDepartament(int departamentId)
        {
            using var db = new SchoolContext();
            var dep = db.Departaments
               .Where(s => s.Id == departamentId)
               .Include(s => s.Students)
               .SingleOrDefault<Departament>();
            if (dep == null)
            {
                Console.WriteLine("There is not such departament");
            }
            else  
            {
                Console.WriteLine($"{dep.Name} departament students list:");
                foreach (var item in dep.Students)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

        //---7--- +++
        public static void PrintAllCoursesOfDepartament(int departamentId)
        {
            using var db = new SchoolContext();
            var dep = db.Departaments
                .Where(s => s.Id == departamentId)
                .Include(s => s.Courses)
                .SingleOrDefault<Departament>();
            if (dep != null)
            {
                Console.WriteLine($"{dep.Name} departament courses list: ");
                foreach (var item in dep.Courses)
                {
                    Console.WriteLine( item.Name);
                }
            }
            else 
            {
                Console.WriteLine("There is no such departament");
            }
        }

        //---8---  +++
        public static void PrintAllCoursesOfStudent(int studentId)
        {
            using var db = new SchoolContext();
            var student = db.Students
                .Where(s => s.Id == studentId)
                .Include(s => s.Courses)
                .SingleOrDefault<Student>();
            if(student != null) 
            { 
                Console.WriteLine($"{student.Name} ");
                foreach (var item in student.Courses)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.WriteLine("There is no such student");
            }
        }
    }
}
