using CS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CS.DAL
{
    public class DashboardContext : DbContext
    {
        public DashboardContext(DbContextOptions<DashboardContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Customer_Car> Customer_Cars { get; set; }
        public DbSet<Car_Status> Car_Statuses { get; set; }
    }
}
