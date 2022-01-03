using AlterTankBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AlterTankBackend.Database
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new Configuration());
            builder.Entity<Plugs>().HasOne(prop => prop.fuel).WithMany(_prop => _prop.plugs).HasForeignKey(prop => prop.fuelId);
            builder.Entity<Prices>().HasOne(prop => prop.Station).WithMany(_prop => _prop.prices).HasForeignKey(prop => prop.stationId);
            builder.Entity<PlugsStations>().HasKey(prop => new { 
            prop.PlugId,
            prop.StationId
            });
        }
        public DbSet<Stations> Station { get; set; }
        public DbSet<Fuels> Fuel { get; set; }
        public DbSet<Prices> Prices { get; set; }
        public DbSet<Plugs> Plugs { get; set; }
        public DbSet<PlugsStations> PlugsStations { get; set; }
    }
}
