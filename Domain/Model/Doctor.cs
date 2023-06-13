﻿using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Doctor
    {
        [Key]
        public int? DoctorId { get; set; }
        public string? Name { get; set; }
        public Gender? Gender { get; set; }
        public string? Specialization { get; set; }
        public string? Experience { get; set; }
        public string? ContactNo { get; set; }
        public string? EmailId { get; set; }
        public string? Schedule { get; set; }
        [NotMapped]
        public DateOnly? CreatedAt { get; set; }
        [NotMapped]
        public DateOnly? UpdatedAt { get; set;}
        public ICollection<Patient>? Patient { get; set; }
    }
}
