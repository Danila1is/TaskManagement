using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Teams
{
    public class Team
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public string? PicturePath { get; set; }

        public required string InviteUrl { get; set; } 

        public required Guid UserId { get; set; } // Creator

        public List<TeamMember> TeamMembers { get; set; } = [];

        public List<Role> Roles { get; set; } = [];
    }
}
