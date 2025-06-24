using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Teams
{
    public class Role
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public List<Function> Functions { get; set; } = [];

        public required Team Team {  get; set; }

        public List<TeamMember> TeamMembers { get; set; } = [];
    }
}
