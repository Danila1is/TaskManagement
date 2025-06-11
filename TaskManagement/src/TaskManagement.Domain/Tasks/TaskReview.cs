using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Tasks
{
    public class TaskReview
    {
        public Guid Id { get; set; }

        public string? FeedBack { get; set; }

        public List<string> Attachments { get; set; } = [];

        public required string Status { get; set; }

        public required TaskDelivery TaskDelivery { get; set; }

        public required Guid InspectorId { get; set; }

        public DateTime DateOfInspection { get; set; }
    }
}
