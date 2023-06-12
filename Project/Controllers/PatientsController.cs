using BAL;
using BAL.Helpers;
using BAL.Interface;
using BAL.Service;
using DAL.Interface;
using Domain.Enums;
using Domain.Model;
using Domain.Model.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Numerics;

namespace MVCProject.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;

        }

        public async Task<IActionResult>  Index(Gender? filterOption, string name, int page = 1, int pageSize = 5)
        {
            IEnumerable<PatientViewModel> patients = await _patientService.GetAllPatients(name);
      
            if (filterOption.HasValue)
            {
                patients = patients.Where(p => p.Gender == filterOption.Value);
                return RedirectToAction("Index");
            }
            var patientViewModels = patients.Select(p => new PatientViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Gender = p.Gender,
                DateOfBirth = p.DateOfBirth,

            });
            var paginatedDoctors = patientViewModels.Paginate(page, pageSize);

            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = patients.Count();
            ViewBag.name = name;

            return View(paginatedDoctors);
        }
      
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientViewModel patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _patientService.AddPatient(patient);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while adding the patient: " + ex.Message);
                }
            }

            return View(patient);
        }
        


        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _patientService.GetPatientById(id);
            if (patient == null)
            {
              
                return NotFound();
            }

            
            var patientViewModel = new PatientViewModel
            {
                Id = patient.Id,
                Name = patient.Name,
                Gender= patient.Gender,
                DateOfBirth = patient.DateOfBirth,
            };

            return View(patientViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PatientViewModel patientViewModel)
        {
            if (ModelState.IsValid)
            {
               
                var patientDto = new PatientViewModel
                {
                    Id = patientViewModel.Id,
                    Name = patientViewModel.Name,
                    Gender = patientViewModel.Gender,
                    DateOfBirth = patientViewModel.DateOfBirth,
                };

               
                await _patientService.UpdatePatient(patientDto);

                return RedirectToAction("Index");
            }

            return View(patientViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var patient = await _patientService.GetPatientById(id);
            if (patient == null)
            {
                
                return NotFound();
            }

            
            var patientViewModel = new PatientViewModel
            {
                Id = patient.Id,
                Name = patient.Name,
               Gender = patient.Gender,
               DateOfBirth= patient.DateOfBirth,
            };

            return View(patientViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            await _patientService.DeletePatient(id);

            return RedirectToAction("Index");
        }

    }
}
