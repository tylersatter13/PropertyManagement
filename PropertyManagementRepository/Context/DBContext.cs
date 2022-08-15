using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PropertyManagement.Models;
using PropertyManagementRepository.Models;

namespace PropertyManagement
{
    public class EFDBContext:DbContext
    {
        private readonly string _connectionString;
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public EFDBContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionString");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}