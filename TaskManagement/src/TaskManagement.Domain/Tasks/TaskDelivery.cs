using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Tasks
{
    public class TaskDelivery
    {
        public Guid Id { get; set; }

        public required TaskItem TaskItem { get; set; }

        public Guid? TaskReviewId { get; set; }

        public TaskReview? TaskReview { get; set; }

        public required string Comment { get; set; }

        public List<string> Attachments { get; set; } = [];

        public required Guid TeamMemberId { get; set; }

        public DateTime SentDate { get; set; }
    }
}
