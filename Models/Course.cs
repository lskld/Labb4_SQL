using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4_SQL.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [StringLength(100)]
        public required string CourseName { get; set; }
        public ICollection<ClassCourse> ClassCourses { get; set; } = new List<ClassCourse>();
    }
}
