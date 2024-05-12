﻿// <auto-generated />
using System;
using Classes.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MS_SQL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Classes.models.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciseId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExerciseId");

                    b.HasIndex("TrainingId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Classes.models.PhysicalMetrics", b =>
                {
                    b.Property<int>("PhysicalMetricsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhysicalMetricsId"));

                    b.Property<float>("BodyMeasurements")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Pulse")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserIsnNode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("PhysicalMetricsId");

                    b.HasIndex("UserIsnNode");

                    b.ToTable("PhysicalMetricss");
                });

            modelBuilder.Entity("Classes.models.Training", b =>
                {
                    b.Property<int>("TrainingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainingId"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainingProgramId")
                        .HasColumnType("int");

                    b.HasKey("TrainingId");

                    b.HasIndex("TrainingProgramId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Classes.models.TrainingProgram", b =>
                {
                    b.Property<int>("TrainingProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainingProgramId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Goals")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserIsnNode")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TrainingProgramId");

                    b.HasIndex("UserIsnNode");

                    b.ToTable("TrainingPrograms");
                });

            modelBuilder.Entity("Classes.models.User", b =>
                {
                    b.Property<Guid>("IsnNode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IsnNode");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Classes.models.Exercise", b =>
                {
                    b.HasOne("Classes.models.Training", "Training")
                        .WithMany("Exercises")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");
                });

            modelBuilder.Entity("Classes.models.PhysicalMetrics", b =>
                {
                    b.HasOne("Classes.models.User", "User")
                        .WithMany("PhysicalMetrics")
                        .HasForeignKey("UserIsnNode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Classes.models.Training", b =>
                {
                    b.HasOne("Classes.models.TrainingProgram", "TrainingProgram")
                        .WithMany("Trainings")
                        .HasForeignKey("TrainingProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingProgram");
                });

            modelBuilder.Entity("Classes.models.TrainingProgram", b =>
                {
                    b.HasOne("Classes.models.User", "User")
                        .WithMany("TrainingPrograms")
                        .HasForeignKey("UserIsnNode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Classes.models.Training", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("Classes.models.TrainingProgram", b =>
                {
                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("Classes.models.User", b =>
                {
                    b.Navigation("PhysicalMetrics");

                    b.Navigation("TrainingPrograms");
                });
#pragma warning restore 612, 618
        }
    }
}
