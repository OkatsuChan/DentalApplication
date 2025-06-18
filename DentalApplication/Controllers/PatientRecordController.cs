using DentalApplication.Data;
using DentalApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DentalApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientRecordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientRecordController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("UploadRecord")]
        public IActionResult CreatePatientRecord([FromForm] PatientRecordModel patient)
        {
            if (patient == null)
            {
                return BadRequest("Invalid data.");
            }

            patient.LastAccessed = DateTime.Now;
            patient.DateCreated = DateOnly.FromDateTime(DateTime.Now);
            patient.ReasonforAccess = "New Patient Record Creation";
            patient.AccessedBy = "AdminTest"; 

            // Save patient to Database Using Forms
            _context.tblPatientRecord.Add(patient);
            _context.SaveChanges();

            return Ok(new { message = "Patient record saved successfully!" });
        }
    }
}
