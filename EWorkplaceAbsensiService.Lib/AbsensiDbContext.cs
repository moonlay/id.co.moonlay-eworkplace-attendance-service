using Com.Moonlay.Data.EntityFrameworkCore;
using EWorkplaceAbsensiService.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace EWorkplaceAbsensiService.Lib
{
    public class AbsensiDbContext : StandardDbContext
    {
        public AbsensiDbContext(DbContextOptions<AbsensiDbContext> options) : base(options)
        {
        }

        public DbSet<Absensi> Absensis { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
