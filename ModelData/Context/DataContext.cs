using Microsoft.EntityFrameworkCore;
using ModelData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelData.Context
{
    public class DataContext: DbContext
    {
        public DbSet<Boss> Bosses { get; set; } = null!;
        public DbSet<Staff> Staffs { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<ModelData.Model.Task> Tasks { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=TaskManagementSystem;Username=postgres;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boss>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Boss>()
                .Property(e => e.ModifiedDate)
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Staff>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Staff>()
                .Property(e => e.ModifiedDate)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<ModelData.Model.Task>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<ModelData.Model.Task>()
                .Property(e => e.ModifiedDate)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Boss>()
                .HasIndex(x => x.Mail).IsUnique();

            modelBuilder.Entity<Staff>()
                .HasIndex(x => x.Mail).IsUnique();
        }
    }
}
