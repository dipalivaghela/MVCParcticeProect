using BAL.DoctorService;
using BAL.Service;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace MVCPracticeProject.Controllers
{
    public class DropdownController : Controller
    {
        
            private readonly IDoctorService _doctorService;
            private readonly IPatientService _patientService;

            public DropdownController(IDoctorService doctorService, IPatientService patientService)
            {
                _doctorService = doctorService;
                _patientService = patientService;
            }
             public async Task<IActionResult> Index(int doctorId)
        {
            var doctors = await _doctorService.GetAllDoctors();
            var patients = await _patientService.GetPatientsByDoctorId(doctorId);

            var viewModel = new DoctorPatient
            {
                Doctors = doctors.ToList(),
                Patients = patients.ToList()
            };

            return View(viewModel);
        }

        /*   public async Task<IActionResult> Index(int doctorId)
           {
               var doctors = await _doctorService.GetAllDoctors();

           var viewModel = new DoctorPatient
               {
                   Doctors = doctors.ToList(),
           };
               return View(viewModel);
           }*/

        [HttpPost]
            public async Task<IActionResult> GetPatientsByDoctorId(int doctorId)
            {
                var patients = await _patientService.GetPatientsByDoctorId(doctorId);
                return Json(patients);
            }
        }
}
