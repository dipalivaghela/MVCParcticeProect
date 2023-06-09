using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Patient
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? BloodGroup { get; set; }
        public string? ContactNo { get; set; }
        public string? EmailId { get; set; }
        public string? Address { get; set; }
        public int? DoctorId { get; set; }
    }
}
