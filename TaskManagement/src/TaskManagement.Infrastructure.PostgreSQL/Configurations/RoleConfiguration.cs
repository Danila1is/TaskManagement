using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Teams;

namespace TaskManagement.Infrastructure.PostgreSQL.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.Functions)
                .HasConversion<int>();

            builder.HasOne(x => x.Team)
                .WithMany(x => x.Roles);

            builder.HasMany(x => x.TeamMembers)
                .WithOne(x => x.Role);
        }
    }
}
