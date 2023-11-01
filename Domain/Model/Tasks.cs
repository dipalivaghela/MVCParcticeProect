using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        /*public bool IsCompleted { get; set; }*/
        public TaskStatus Status { get; set; }

    }
    public enum TaskStatus
    {
        All,
        InProgress,
        Completed
    }
}
