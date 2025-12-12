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
                    .ThenInclude(s => s.Class)
                .Include(g => g.Course)
                .Where(g => g.Student.Class.ClassName == classChoice)
                .ToList();                

            foreach (var student in studentsInClass)
            {
                Console.WriteLine($"Student Name: {student.FirstName} {student.LastName}\nClass: {student.Class.ClassName}\n\nCourses and grades:");

                foreach (var course in student.Class.Courses)
                {
                    var gradeForCourse = gradesForClass
                        .Where(g => g.StudentId == student.StudentId)
                        .Where(g => g.Course == course)
                        .ToList();
                    
                    if(course.IsActive)
                    {
                        Console.WriteLine($"{course} | Not Graded");
                    }
                    else
                    {
                        foreach (var grade in gradeForCourse)
                            Console.WriteLine($"{course} | Grade: {grade}");
                    }
                }
                Console.WriteLine("\n--------------------------------------\n");
            }
                
        }
    }
}
