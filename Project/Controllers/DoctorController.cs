using BAL.DoctorService;
using ClosedXML.Excel;
using Domain.Enums;
using Domain.Model;
using Domain.Model.Dtos;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace MVCPracticeProject.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task<IActionResult> Index()
           {
            var doctors = await _doctorService.GetAllDoctors();
            return View(doctors);
        }

        [HttpPost]
        public IActionResult Import(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var excelStream = file.OpenReadStream())
                {
                    _doctorService.ImportDataFromExcel(excelStream);
                }
            }     
            return RedirectToAction("Index");
        }     
    }
}

