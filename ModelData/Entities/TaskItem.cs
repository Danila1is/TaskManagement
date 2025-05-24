using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelData.Model
{
    public class TaskItem
    {
        public int Id { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; } = null!;
        [Column(TypeName = "varchar(25)")]
        public string Status { get; set; } = null!;
        public DateTime? DateStart { get; set; } = null!;
        public DateTime? DateEnd { get; set; }
        public DateTime? DateDone { get; set; }
        [Column(TypeName = "text")]
        public string? Reply { get; set; }
        public int StaffId { get; set; }
        public Staff? Staff { get; set; }
        public int BossId { get; set; }
        public Boss? Boss { get; set; }
        public DateTimeOffset? CreatedDate { get; } = null!;
        public DateTimeOffset? ModifiedDate { get; set; }

    }
}
