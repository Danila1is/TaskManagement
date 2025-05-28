using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core.Models
{
    public class RoleModel
    {

        private RoleModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Required]
        public int Id { get; }
        [Required]
        public string Name { get; }

        public static (RoleModel role, List<ValidationResult> errors) Create(int id, string name)
        {
            RoleModel roleModel = new RoleModel(id, name);
            List<ValidationResult> errors = new List<ValidationResult>();
            var context = new ValidationContext(roleModel);

            Validator.TryValidateObject(roleModel, context, errors, true);
            return (roleModel, errors);
        }
    }
}
