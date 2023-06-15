using DAL.GenericInterface;
using Domain.Model;
using Domain.Model.Dtos;
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
        //void Insert(Doctor newData);

        //Task BulkInsertDoctors(List<Doctor> doctors);

        void InsertExcel(Doctor doctor);
        //Task BulkInsert(List<Doctor> doctorEntities);
        /*Task<Patient> GetPatientByIdAsync(int id);
Task AddPatientAsync(Patient patient);
Task UpdatePatientAsync(Patient patient);
Task DeletePatientAsync(Patient patient);
Task<IEnumerable<Patient>> SearchPatientsByNameAsync(string name);*/
    }
}
