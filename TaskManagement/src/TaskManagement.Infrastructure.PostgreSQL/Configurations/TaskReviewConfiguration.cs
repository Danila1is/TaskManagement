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
    public class TaskReviewConfiguration: IEntityTypeConfiguration<TaskReview>
    {
        public void Configure(EntityTypeBuilder<TaskReview> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
