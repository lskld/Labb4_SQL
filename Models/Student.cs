using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Labb4_SQL.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [StringLength(100)]
        public required string FirstName { get; set; }
        [StringLength(100)]
        public required string LastName { get; set; }
        [StringLength(13)]
        public string? PersonalNumber { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; } = null!;
    }
}
