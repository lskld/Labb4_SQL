using Microsoft.EntityFrameworkCore;

namespace Labb4_SQL.Models
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext() { }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Connection string is missing");
            
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            /*Creating a 1:1 relationship between Class & Employee:
             *This makes the index EmployeeId unique for each class, so it can only have one responsible teacher,
             *and each teacher/employee can only be responsible for one class. The relationship is made using the 
             *foreign key EmployeeId, which allows navigation between Class and Employee.
             */

            modelBuilder.Entity<Class>()
                .HasIndex(c => c.EmployeeId)
                .IsUnique();

            modelBuilder.Entity<Class>()
                .HasOne(c => c.ResponsibleTeacher)
                .WithOne(e => e.ResponsibleForClass)
                .HasForeignKey<Class>(c => c.EmployeeId)
                .IsRequired(false);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
