using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core.Models
{
    public class TaskItemModel
    {
        private TaskItemModel(int id, string description, string status, DateTime dateStart, DateTime dateEnd, 
            DateTime? dateDone = null, string? reply = null)
        {
            Id = id;
            Description = description;
            Status = status;
            DateStart = dateStart;
            DateEnd = dateEnd;
            DateDone = dateDone;
            Reply = reply;
        }

        [Required]
        public int Id { get;}
        [Required]
        public string Description { get;}
        [Required]
        public string Status { get;}
        [Required]
        public DateTime DateStart { get;}
        [Required]
        public DateTime DateEnd { get;}
        public DateTime? DateDone { get;}
        public string? Reply { get;}

        public static (TaskItemModel TaskItemModel, List<ValidationResult> errors) Create(int id, string description, string status, 
            DateTime dateStart, DateTime dateEnd, DateTime? dateDone = null, string? reply = null)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            var taskItemModel = new TaskItemModel(id, description, status, dateStart, dateEnd, dateDone, reply);
            var contextValidator = new ValidationContext(taskItemModel);

            Validator.TryValidateObject(taskItemModel, contextValidator, errors, true);

            return (taskItemModel, errors);
        }

    }
}
