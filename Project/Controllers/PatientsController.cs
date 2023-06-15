using BAL;
using BAL.Helpers;
using BAL.Service;
using DAL.Interface;
using Domain.Enums;
using Domain.Model;
using Domain.Model.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;


namespace MVCProject.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientService _patientService;

      
      

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
           
        }
        public async Task<IActionResult> Index(Gender? filterOption, string searchName, int page = 1, int pageSize = 5)
        {
            
            IEnumerable<PatientDto> patients;

            if (!string.IsNullOrEmpty(searchName))
            {
                patients = await _patientService.SearchPatientsByName(searchName);
            }
            else
            {
                patients = await _patientService.GetAllPatients();
            }
            
            if (filterOption.HasValue)
            {
                patients = patients.Where(p => p.Gender == filterOption.Value);
                return RedirectToAction("Index");
            }

            var patientViewModels = patients.Select(p => new PatientDto
            {
                Id = p.Id,
                Name = p.Name,
                Gender = p.Gender,
                DateOfBirth = p.DateOfBirth
            });

            var paginatedPatients = patientViewModels.Paginate(page, pageSize);

            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = patients.Count();
            ViewBag.SearchName = searchName;

            return View(paginatedPatients);
        }

        public IActionResult Create()
        {
           /* var patientDto = new PatientDto();
            return View(patientDto);*/
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientDto patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _patientService.AddPatient(patient);
                    return PartialView("_CreatePartial", new PatientDto());
                  //  return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while adding the patient: " + ex.Message);
                }
            }
            return PartialView("_CreatePartial", patient);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _patientService.GetPatientById(id);
            if (patient == null)
            {    
                return NotFound();
            }
 
            var patientViewModel = new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                Gender= patient.Gender,
                DateOfBirth = patient.DateOfBirth,
                DoctorId = patient.DoctorId,
            };
            return View(patientViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PatientDto patientViewModel)
        {
            if (ModelState.IsValid)
            {            
                var patientDto = new PatientDto
                {
                    Id = patientViewModel.Id,
                    Name = patientViewModel.Name,
                    Gender = patientViewModel.Gender,
                    DateOfBirth = patientViewModel.DateOfBirth,
                    DoctorId= patientViewModel.DoctorId,
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
            
            var patientViewModel = new PatientDto
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
        /*[HttpGet]
        public async Task<IActionResult> GetPatientsByDoctorId(int doctorId)
        {
            var patients = await _patientService.GetPatientsByDoctorId(doctorId);
            return Json(patients);
        }*/
        
        [HttpGet]
        public async Task<IActionResult> SearchPatientsByName(string name)
        {

            var patients = await _patientService.SearchPatientsByName(name);
            var patientNames = patients.Select(p => p.Name).ToList();
            return Json(patientNames);
        }


    }
}
