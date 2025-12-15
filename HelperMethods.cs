using Labb4_SQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb4_SQL
{
    public class HelperMethods
    {
        public static void ShowTeachersInDepartment(SchoolDbContext context)
        {
            var departments = context.Departments
                            .Include(d => d.Employees)
                                .ThenInclude(e => e.Role)
                            .ToList();

            foreach (var department in departments)
            {
                List<Employee> teachers = new List<Employee>();

                foreach (var employee in department.Employees)
                {
                    if (employee.Role.RoleName.Equals("Teacher"))
                        teachers.Add(employee);
                }

                Console.WriteLine($"{department.DepartmentName}: {teachers.Count} teachers");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static void ShowStudentInformation(SchoolDbContext context, string classChoice)
        {
            var studentsInClass = context.Students
                .Where(s => s.Class.ClassName == classChoice)
                .Include(s => s.Class)
                    .ThenInclude(c => c.Courses)
                .ToList();

            var gradesForClass = context.Grades
                .Include(g => g.Student)
                .Include(g => g.Course)
                .Where(g => g.Student.Class.ClassName == classChoice)
                .ToList();

            foreach (var student in studentsInClass)
            {
                Console.WriteLine($"Student Name: {student.FirstName} {student.LastName}\nClass: {student.Class.ClassName}\n\nCourses and grades:");

                foreach (var course in student.Class.Courses)
                {
                    var gradeForCourse = gradesForClass
                        .FirstOrDefault(g => g.StudentId == student.StudentId && g.CourseId == course.CourseId);

                    if (gradeForCourse != null)
                    {
                        Console.WriteLine($"{course} | Grade: {gradeForCourse.SetGrade}");
                    }

                    else
                    {
                        Console.WriteLine($"{course} | Grade: Not Graded");
                    }
                }

                Console.WriteLine("\n--------------------------------------\n");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static void ShowActiveCourses(SchoolDbContext context)
        {
            var activeCourses = context.Courses
                .Where(c => c.IsActive)
                .ToList();

            Console.WriteLine("All active courses in the school:");
            foreach (var course in activeCourses)
                Console.WriteLine($"Status: Active | Course Name: {course}");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static void GradeStudent(SchoolDbContext context, Course course, Student student, char grade, Employee teacher)
        {
            if (teacher != null && student != null && course != null)
            {
                Grade newGrade = new Grade
                {
                    SetGrade = grade,
                    GradingDate = DateOnly.FromDateTime(DateTime.Today.AddYears(91)),
                    EmployeeId = teacher.EmployeeId,
                    StudentId = student.StudentId,
                    CourseId = course.CourseId
                };
                
                context.Grades.Add(newGrade);
                context.SaveChanges();

                Console.WriteLine("The grade was successfully set and added to the database.\n");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("Necessary information is missing. Try again.");
            }
        }
    }
}
