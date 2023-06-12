using Microsoft.AspNetCore.Mvc;

namespace MVCPracticeProject.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
           return View();
        }
    }
}
