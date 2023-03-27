using Microsoft.EntityFrameworkCore;
using UnitTestMoqFinal.Models;

namespace UnitTestMoqFinal.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DbContextClass(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<User> Users { get; set; }
    }
}
