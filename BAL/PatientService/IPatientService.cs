using DAL.Interface;
using Domain.Model;
using Domain.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllPatients();
        Task<PatientDto> GetPatientById(int id);
        Task AddPatient(PatientDto patients);
        Task UpdatePatient(PatientDto patient);
        Task DeletePatient(int id);
        Task<IEnumerable<PatientDto>> SearchPatientsByName(string name);
        //Task<IEnumerable<PatientDto>> GetPatientsByDoctorId(int doctorId); 
        Task<IEnumerable<Patient>> GetPatientsByDoctorId(int doctorId);

    }
}

