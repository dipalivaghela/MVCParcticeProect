using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class DoctorPatient
    {
        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; }
    }

}
