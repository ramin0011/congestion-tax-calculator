using Microsoft.EntityFrameworkCore;
using System;
using congestion.calculator.Models.Congestion;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace congestion_tax_calculator_net_core_data
{
    public class CongestionDbContext : DbContext
    {
        public CongestionDbContext(DbContextOptions<CongestionDbContext> options) : base(options)
        {
        }

        public DbSet<CongestionTime> CongestionTimes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CongestionTime>()
                .Property(s => s.StartTime)
                .HasConversion(new TimeSpanToTicksConverter());

            modelBuilder.Entity<CongestionTime>()
                .Property(s => s.EndTime)
                .HasConversion(new TimeSpanToTicksConverter());


            base.OnModelCreating(modelBuilder);
        }

        public static CongestionDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<CongestionDbContext>()
                .UseInMemoryDatabase("test")
                .Options;

            return new CongestionDbContext(options);

        }
    }
}
