using BAL;
using BAL.Helpers;
using BAL.Interface;
using BAL.Service;
using DAL.Interface;
using Domain.Enums;
using Domain.Model;
using Domain.Model.ViewModel;
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

        public async Task<IActionResult> Index(Gender? filterOption, string name, int page = 1, int pageSize = 2)
        {
            IEnumerable<PatientViewModel> patients;

            if (!string.IsNullOrEmpty(name))
            {
                patients = await _patientService.GetDoctorsByName(name);
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
         
            var paginatedDoctors = patients.Paginate(page, pageSize);

            ViewBag.PageNumber = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = patients.Count();
            return View(patients);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(PatientViewModel patient)
        {
            if (ModelState.IsValid)
            {
               await _patientService.AddPatient(patient);
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        public async Task <IActionResult> Edit(int id)
        {
            PatientViewModel patient = await _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost]
        public async Task <IActionResult> Edit(int id, PatientViewModel patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               await _patientService.UpdatePatient(patient);
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        public async Task <IActionResult> Delete(int id)
        {
            PatientViewModel patient = await _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            PatientViewModel patient = await _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            await _patientService.DeletePatient(patient);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> GetDoctorsByName(string Name)
        {
            var patients = await _patientService.GetDoctorsByName(Name);          
            return View(patients);
        }
    }
}
