using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Labb4_SQL.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [StringLength(100)]
        public required string FirstName { get; set; }
        [StringLength(100)]
        public required string LastName { get; set; }
        public int YearsEmployed { get; set; }
        public int Salary { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public Class? ResponsibleForClass { get; set; }
    }
}
