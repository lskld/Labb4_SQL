using System;
using System.Collections.Generic;
using System.Text;

namespace Labb4_SQL.Models
{
    public class ClassCourse
    {
        public int ClassId { get; set; }
        public int CourseId { get; set; }

        public Class Class { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
