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
    public class TaskDeliveryConfiguration: IEntityTypeConfiguration<TaskDelivery>
    {
        public void Configure(EntityTypeBuilder<TaskDelivery> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.TaskItem)
                .WithMany(x => x.TaskDeliveries);

            builder.HasOne(x => x.TaskReview)
                .WithOne(x => x.TaskDelivery)
                .HasForeignKey<TaskDelivery>(x => x.TaskReviewId);

            builder.HasIndex(x => x.TaskReviewId)
                .IsUnique();
        }
    }
}
