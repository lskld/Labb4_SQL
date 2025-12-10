using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4_SQL.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        public required char SetGrade { get; set; }
        public required DateTime GradingDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Teacher { get; set; } = null!;
    }
}
