using DAL.GenericInterface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DoctorRepo
{
    public interface IDoctorRepo :IGenericRepo<Doctor>
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        /*Task<Patient> GetPatientByIdAsync(int id);
        Task AddPatientAsync(Patient patient);
        Task UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(Patient patient);
        Task<IEnumerable<Patient>> SearchPatientsByNameAsync(string name);*/
    }
}
