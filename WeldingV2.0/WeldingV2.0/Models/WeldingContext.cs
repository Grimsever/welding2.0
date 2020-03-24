using Microsoft.EntityFrameworkCore;

namespace WeldingV2._0.Models
{
    public class WeldingContext : DbContext
    {
        public DbSet<Workers> Workers { get; set; }

        public DbSet<Foremen> Foremen { get; set; }

        public DbSet<Machine> Machines { get; set; }

        public DbSet<MachineData> MachineDatas { get; set; }

        public DbSet<Amperage> Amperages { get; set; }

        public DbSet<Voltage> Voltages { get; set; }

        public DbSet<TechMap> TechMaps { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public WeldingContext(DbContextOptions<WeldingContext> options) : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate();
        }
    }
}
