using DAL.GenericInterface;
using Domain.Model;
using Domain.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IPatientRepo : IGenericRepo<Patient>
    {        
            Task<IEnumerable<Patient>> GetAllPatientsAsync();
            Task<Patient> GetPatientByIdAsync(int id);
            Task AddPatientAsync(Patient patient);
            Task UpdatePatientAsync(Patient patient);
            Task DeletePatientAsync(Patient patient);
            Task<IEnumerable<Patient>> SearchPatientsByNameAsync(string name);
            Task<IEnumerable<Patient>> GetPatientsByDoctorIdAsync(int doctorId);
        //   Task<IEnumerable<Patient>> GetPatientsByDoctorId(int doctorId); 

    }

}

