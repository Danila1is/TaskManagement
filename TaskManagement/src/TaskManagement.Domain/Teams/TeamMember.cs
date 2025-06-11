using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Teams
{
    public class TeamMember
    {
        public Guid Id { get; set; }

        public required Guid UserId { get; set; }

        public required Guid TeamId { get; set; }

        public required Guid RoleId { get; set; }
    }
}
