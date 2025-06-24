using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Tasks;

namespace TaskManagement.Infrastructure.PostgreSQL.Configurations
{
    public class TaskItemConfiguration: IEntityTypeConfiguration<TaskItem>
    {
        public void Configure (EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Status)
                .HasConversion<int>();
            builder.Property(x => x.Priority)
                .HasConversion<int>();

            builder.HasMany(x => x.TaskDeliveries)
                .WithOne(x => x.TaskItem);
        }
    }
}
