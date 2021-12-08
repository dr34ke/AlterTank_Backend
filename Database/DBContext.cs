using AlterTankBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AlterTankBackend.Database
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfiguration(new Configuration());
        public DbSet<Stations> Station { get; set; }
    }
}
