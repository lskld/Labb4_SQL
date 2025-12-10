using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4_SQL.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [StringLength(100)]
        public required string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
