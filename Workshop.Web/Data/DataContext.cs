using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Workshop.Web.Data.Entities;

namespace Workshop.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
