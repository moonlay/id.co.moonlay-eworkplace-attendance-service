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
        public DbSet<Project> Project { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityCategory> ActivityCategory { get; set; }
        public DbSet<TaskManangement> TaskManangement { get; set; }

        public DbSet<TimeSheet> TimeSheet { get; set; }
        public DbSet<Report> Reports { get; set; }

        public DbSet<Transport> Transports { get; set; }
        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<Medical> Medicals { get; set; }
        public DbSet<Other> Others { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
