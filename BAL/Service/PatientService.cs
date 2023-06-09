using BAL.Interface;
using DAL.DBContext;
using DAL.GenericInterface;
using DAL.Interface;
using DAL.Repo;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class PatientService : IPatientService 
    {
        private readonly IPatientRepo _patientRepo;

        public PatientService(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task AddPatient(Patient patient)
        {
            await _patientRepo.AddPatientAsync(patient);
        }

        public async Task DeletePatient(Patient patient)
        {
           await _patientRepo.DeletePatientAsync(patient);
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await _patientRepo.GetAllPatientsAsync();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _patientRepo.GetPatientByIdAsync(id);
        }

        public async Task UpdatePatient(Patient patient)
        {
           await _patientRepo.UpdatePatientAsync(patient);
            
        }
    }
}
