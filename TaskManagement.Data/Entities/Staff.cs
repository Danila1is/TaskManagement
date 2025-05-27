using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Data.Entities
{
    public class Staff
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; } = null!;
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; } = null!;
        [Column(TypeName = "varchar(50)")]
        public string? Patronymic { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string? FullName => $"{FirstName} {LastName} {Patronymic}".Trim();
        public DateOnly? Birthday { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Mail { get; set; } = null!;
        [Column(TypeName = "varchar(11)")]
        public string? PhoneNumber { get; set; }
        [Column(TypeName = "varchar(64)")]
        public string PasswordHash { get; set; } = null!;
        public int BossId { get; set; }
        public Boss? Boss { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public List<TaskItem> Tasks { get; set; } = new();
        public DateTimeOffset? CreatedDate { get; } = null!;
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
