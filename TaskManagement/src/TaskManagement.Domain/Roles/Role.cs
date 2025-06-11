using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Roles
{
    public class Role
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public List<Functional> Functionals { get; set; } = [];
    }
}
