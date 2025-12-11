using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4_SQL.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [StringLength(100)]
        public required string ClassName { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();

        public int? EmployeeId { get; set; }
        public Employee? ResponsibleTeacher { get; set; }
    }
}
