using Microsoft.AspNetCore.Mvc;

namespace DentalApplication.Controllers
{
    public class PatietRecordViewController : Controller
    {
        public IActionResult HomePatientRecord()
        {
            return View();
        }
        public IActionResult ViewPatientRecord()
        {
            return View();
        }
    }
}
