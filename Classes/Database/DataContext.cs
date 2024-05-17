using Classes.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Train> Trains{ get; set; }

        public virtual DbSet<PhysicalMetrics> PhysicalMetricss { get; set; }

        public virtual DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.Train)
                .WithMany(t => t.Exercises)
                .HasForeignKey(e => e.TrainingId);

            modelBuilder.Entity<PhysicalMetrics>()
                .HasOne(pm => pm.User)
                .WithMany(u => u.PhysicalMetrics)
                .HasForeignKey(pm => pm.UserId);

            modelBuilder.Entity<Train>()
                .HasOne(t => t.User)
                .WithMany(u => u.UserTrains)
                .HasForeignKey(t => t.UserId);
        }

    }
}
