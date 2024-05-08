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

        public virtual DbSet<TrainingProgram> TrainingPrograms { get; set; }

        public virtual DbSet<Training> Trainings { get; set; }

        public virtual DbSet<PhysicalMetrics> PhysicalMetricss { get; set; }

        public virtual DbSet<Exercise> Exercises { get; set; }


    }
}
