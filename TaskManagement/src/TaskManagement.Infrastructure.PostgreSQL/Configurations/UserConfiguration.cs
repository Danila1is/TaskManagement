using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Users;

namespace TaskManagement.Infrastructure.PostgreSQL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey((User x) => x.Id);

            builder.Property(x => x.FirstName).HasMaxLength(30);
            builder.Property(x => x.LastName).HasMaxLength(30);
            builder.Property(x => x.Patronymic).HasMaxLength(30);
            builder.Property(x => x.PhoneNumber).HasMaxLength(16);
            builder.HasIndex(x => x.Email).IsUnique();
            
        }
    }
}
