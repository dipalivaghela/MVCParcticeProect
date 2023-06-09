using BAL;
using BAL.Interface;
using BAL.Service;
using DAL.Interface;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MVCProject.Controllers
{
    public class PatientsController : Controller 
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task <IActionResult> Index()
        {
            IEnumerable<Patient> patients = await _patientService.GetAllPatients();
            return View(patients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(Patient patient)
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
            Patient patient = await _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost]
        public async Task <IActionResult> Edit(int id, Patient patient)
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
            Patient patient = await _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Patient patient = await _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            await _patientService.DeletePatient(patient);
            return RedirectToAction("Index");
        }
    }
}
