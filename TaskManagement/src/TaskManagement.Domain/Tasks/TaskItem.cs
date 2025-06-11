using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Tasks
{
    public class TaskItem
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string Status { get; set; }

        public required string Priority { get; set; }

        public List<string> Attachments { get; set; } = [];

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public DateTime DueDate { get; set; }

        public required Guid TeamId { get; set; }

        public required Guid AuthorId { get; set; }

        public required Guid AssigneeId { get; set; }
    }
}
