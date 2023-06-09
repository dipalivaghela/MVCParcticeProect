using DAL.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface IPatientService 
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int id);
       Task AddPatient(Patient patient);
       Task UpdatePatient(Patient patient);
       Task DeletePatient(Patient patient);       
    }
}

