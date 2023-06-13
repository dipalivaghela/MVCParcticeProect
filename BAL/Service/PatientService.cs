using BAL.Interface;
using DAL.Interface;
using Domain.Model;
using Domain.Model.Dtos;
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

        public async Task<IEnumerable<PatientViewModel>> GetAllPatients( )
        {
            var patients = await _patientRepo.GetAllPatientsAsync();

            var patientDtos = patients.Select(p => new PatientViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Gender = p.Gender,
                DateOfBirth = (DateTime)p.DateOfBirth,
                DoctorId = p.DoctorId,
            });

         /*   if (!string.IsNullOrEmpty(name))
            {
                patientDtos = patientDtos.Where(p => p.Name.Contains(name));
            }*/

            return patientDtos;
        }


        public async Task<PatientViewModel> GetPatientById(int id)
        {
            var patient = await _patientRepo.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return null; 
            }

            var patientViewModel = new PatientViewModel
            {
                Id = patient.Id,
                Name = patient.Name,
                Gender = patient.Gender,
                DateOfBirth = (DateTime)patient.DateOfBirth,
                DoctorId= patient.DoctorId,
            };

            return patientViewModel;
        }


        public async Task AddPatient(PatientViewModel patient)
        {
            var patientModel = new Patient
            {
                Id = (int)patient.Id,
                Name = patient.Name,
                Gender = patient.Gender,
                DateOfBirth = patient.DateOfBirth,
                DoctorId = (int)patient.DoctorId,
          
            };

            await _patientRepo.AddPatientAsync(patientModel);
        }

        public async Task UpdatePatient(PatientViewModel patient)
        {
            var patientModel = await _patientRepo.GetPatientByIdAsync((int)patient.Id);

            if (patientModel == null)
                throw new Exception("Patient not found.");

            patientModel.Id = (int)patient.Id;
            patientModel.Name = patient.Name;
            patientModel.Gender = patient.Gender;
            patientModel.DateOfBirth = patient.DateOfBirth;
            patientModel.DoctorId = (int)patient.DoctorId;
      
            await _patientRepo.UpdatePatientAsync(patientModel);
        }

        public async Task DeletePatient(int id)
        {
            var patient = await _patientRepo.GetPatientByIdAsync(id);

            if (patient == null)
                throw new Exception("Patient not found.");

            await _patientRepo.DeletePatientAsync(patient);
        }
      
    }
}

