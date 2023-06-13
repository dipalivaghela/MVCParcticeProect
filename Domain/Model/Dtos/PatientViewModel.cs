using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Dtos
{
    public class PatientViewModel
    {
     //   [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name")]
        [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 25")]
        public string? Name { get; set; }
        public Gender? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? DoctorId { get; set; }
    }
}
