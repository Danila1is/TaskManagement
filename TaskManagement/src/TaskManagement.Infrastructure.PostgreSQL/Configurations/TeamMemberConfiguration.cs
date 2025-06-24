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
    public class TeamMemberConfiguration: IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Team)
                .WithMany(x => x.TeamMembers);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.TeamMembers);
        }
    }
}
