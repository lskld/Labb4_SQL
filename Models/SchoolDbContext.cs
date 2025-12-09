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
    }
}
