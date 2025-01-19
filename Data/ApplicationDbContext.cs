using Entities;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskBase> TaskBases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BugTask> BugTasks { get; set; }
        public DbSet<FeatureTask> FeatureTasks { get; set; }
        public DbSet<GeneralTask> GeneralTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne(u => u.Task)
                .WithOne(u => u.AssignedUser)
                .HasForeignKey<TaskBase>(u => u.AssignedUserId);

            modelBuilder.Entity<TaskBase>()
                .HasDiscriminator<string>("TaskType")
                .HasValue<GeneralTask>("General")
                .HasValue<FeatureTask>("Feature")
                .HasValue<BugTask>("Bug");

            modelBuilder.Entity<TaskBase>()
                .Property(x => x.Status)
                .HasConversion( v => v.ToString(),
                    v => (Status)Enum.Parse(typeof(Status), v));

            modelBuilder.Entity<TaskBase>()
                .Property(x => x.Priority)
                .HasConversion( v => v.ToString(),
                    v => (Priority)Enum.Parse(typeof(Priority), v));
        }
    }
}
