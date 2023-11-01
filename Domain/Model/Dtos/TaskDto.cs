using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Dtos
{
    public class TaskDto
    {
        public int? Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the title")]
        [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 25")]
        public string? Title { get; set; }

        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        //public bool IsCompleted { get; set; }

        /*        public string Status { get; set; }
         *        public TaskStatus Status { get; set; }
        */
        public TaskStatus Status { get; set; }
    }
    public enum TaskStatus
    {
        All,
        InProgress,
        Completed
    }
} 
