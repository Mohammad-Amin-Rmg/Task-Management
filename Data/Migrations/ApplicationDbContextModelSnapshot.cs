﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Entities.TaskBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssignedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("AssignedUserId")
                        .IsUnique()
                        .HasFilter("[AssignedUserId] IS NOT NULL");

                    b.HasIndex("ProjectId");

                    b.ToTable("TaskBases");

                    b.HasDiscriminator<string>("TaskType").HasValue("TaskBase");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.BugTask", b =>
                {
                    b.HasBaseType("Entities.TaskBase");

                    b.Property<int?>("Severity")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Bug");
                });

            modelBuilder.Entity("Entities.FeatureTask", b =>
                {
                    b.HasBaseType("Entities.TaskBase");

                    b.Property<DateTime?>("Estimate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Feature");
                });

            modelBuilder.Entity("Entities.GeneralTask", b =>
                {
                    b.HasBaseType("Entities.TaskBase");

                    b.Property<bool>("IsReviewed")
                        .HasColumnType("bit");

                    b.Property<int?>("ReviewerId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("General");
                });

            modelBuilder.Entity("Entities.TaskBase", b =>
                {
                    b.HasOne("Entities.User", "AssignedUser")
                        .WithOne("Task")
                        .HasForeignKey("Entities.TaskBase", "AssignedUserId");

                    b.HasOne("Entities.Project", null)
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId");

                    b.Navigation("AssignedUser");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.HasOne("Entities.Project", null)
                        .WithMany("Users")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Entities.Project", b =>
                {
                    b.Navigation("Tasks");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Navigation("Task");
                });
#pragma warning restore 612, 618
        }
    }
}
