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
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(30);

            builder.HasIndex(x => x.InviteUrl).IsUnique();

            builder.HasMany(x => x.TeamMembers)
                .WithOne(x => x.Team);

            builder.HasMany(x => x.Roles)
                .WithOne(x => x.Team);
        }
    }
}
