using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Dtos
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Gender? Gender { get; set; }
        public string? Specialization { get; set; }
        public string? Experience { get; set; }
        public string? ContactNo { get; set; }
        public string? EmailId { get; set; }
        public string? Schedule { get; set; }
    }
}
