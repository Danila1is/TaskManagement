using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Tasks;
using TaskManagement.Domain.Teams;
using TaskManagement.Domain.Users;
using TaskManagement.Infrastructure.PostgreSQL.Configurations;

namespace TaskManagement.Infrastructure.PostgreSQL
{
    public class PostgresqlDbContext: DbContext
    {
        public PostgresqlDbContext(DbContextOptions<PostgresqlDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<TeamMember> TeamMembers { get; set; } = null!;
        public DbSet<TaskItem> TaskItems { get; set; } = null!;
        public DbSet<TaskDelivery> TaskDeliveries { get; set; } = null!;
        public DbSet<TaskReview> TaskReviews { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TeamMemberConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new TaskReviewConfiguration());
            modelBuilder.ApplyConfiguration(new TaskItemConfiguration());
            modelBuilder.ApplyConfiguration(new TaskDeliveryConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
