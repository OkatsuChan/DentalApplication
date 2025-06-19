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

        [HttpGet("FindRecord")]
        public IActionResult FindRecord(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return BadRequest("Search query cannot be empty.");
            }

            var searchTerms = searchQuery.Split(' '); // Splits "John Doe" into ["John", "Doe"]

            var patients = _context.tblPatientRecord.Where(p =>
                searchTerms.Any(term => p.FirstName.Contains(term) || p.LastName.Contains(term))
            ).ToList();

            if (!patients.Any())
            {
                return NotFound();
            }

            return Ok(patients);
        }

    }
}
