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
            //Next step to develop
        }
    }
}
