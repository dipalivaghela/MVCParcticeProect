using DAL.Interface;
using Domain.Model;
using Domain.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface IPatientService 
    {
    
        //Task<IEnumerable<PatientViewModel>> GetAllPatients(string name);
        Task<IEnumerable<PatientViewModel>> GetAllPatients();
        Task<PatientViewModel> GetPatientById(int id);
        Task AddPatient(PatientViewModel patients);
       Task UpdatePatient(PatientViewModel patient);
       Task DeletePatient(int id);
      //  Task GetPatientsByName(string name);
       //Task<IEnumerable<PatientViewModel>> GetPatientsByName(string name);
    }
}

