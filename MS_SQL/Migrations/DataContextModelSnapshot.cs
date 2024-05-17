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
                    b.Property<Guid>("IsnNode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TrainingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IsnNode");

                    b.HasIndex("TrainingId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Classes.models.PhysicalMetrics", b =>
                {
                    b.Property<Guid>("IsnNode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("BodyMeasurements")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("IsnNode");

                    b.HasIndex("UserId");

                    b.ToTable("PhysicalMetricss");
                });

            modelBuilder.Entity("Classes.models.Train", b =>
                {
                    b.Property<Guid>("IsnNode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IsnNode");

                    b.HasIndex("UserId");

                    b.ToTable("Trains");
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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IsnNode");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Classes.models.Exercise", b =>
                {
                    b.HasOne("Classes.models.Train", "Train")
                        .WithMany("Exercises")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Train");
                });

            modelBuilder.Entity("Classes.models.PhysicalMetrics", b =>
                {
                    b.HasOne("Classes.models.User", "User")
                        .WithMany("PhysicalMetrics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Classes.models.Train", b =>
                {
                    b.HasOne("Classes.models.User", "User")
                        .WithMany("UserTrains")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Classes.models.Train", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("Classes.models.User", b =>
                {
                    b.Navigation("PhysicalMetrics");

                    b.Navigation("UserTrains");
                });
#pragma warning restore 612, 618
        }
    }
}
