// See https://aka.ms/new-console-template for more information
using EntityFrameworkProject;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System.Linq;

Console.WriteLine("Hello, World!");


//1+++

var studentList = new List<Student>() { new Student() { Name = "Monika" }, new Student() { Name = "Veronika" } };  
var coursesList = new List<Course>() { new Course() { Name = "Painting"}, new Course() { Name = "Graphics"} };
//SchoolDbService.CreateDepartamentAndAddStudentsAndCourses("Arts", studentList, coursesList);

//2+++
var courses = new List<Course>();
courses.Add(new Course() { Name = "Marketing" });
courses.Add(new Course() { Name = "Combinatorics" });

var students = new List<Student>();
students.Add(new Student() { Name = "Rokas" });
students.Add(new Student() { Name = "Violeta" });
//SchoolDbService.AddStudentsAndCoursesToEgsistingDepartament(5, students, courses);

//3+++
// SchoolDbService.CreateCourseAndAddToExistingDepartament("Photography", 6);

//4+++
// SchoolDbService.CreateStudentAndAddToEgsistingDepartament("Margarita", 6) ;

//5 +++
// SchoolDbService.TransferStudentToOtherDepartament(1, 2);

//6 +++
 // SchoolDbService.PrintAllStudentsOfDepartament(6);

//7 +++
// SchoolDbService.PrintAllCoursesOfDepartament(6);

//8 +++
// SchoolDbService.PrintAllCoursesOfStudent(1);


