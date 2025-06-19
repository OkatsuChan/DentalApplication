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
        public IActionResult FindRecord(string searchQuery, int page = 1, int limit = 5)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return BadRequest("Search query cannot be empty.");
            }

            int skip = (page - 1) * limit;

            // Get filtered results first (before pagination)
            var filteredPatients = _context.tblPatientRecord
                .Where(p => p.FirstName.Contains(searchQuery) || p.LastName.Contains(searchQuery));

            int totalFilteredRecords = filteredPatients.Count(); // Get the correct count of matching records

            var patients = filteredPatients
                .OrderBy(p => p.LastAccessed) // Sort by last visit date (Optional)
                .Skip(skip) // Skip previous pages
                .Take(limit) // Limit results per page
                .ToList();

            return Ok(new { patients, totalRecords = totalFilteredRecords });
        }

        [HttpGet("ShowAllRecord")]
        public IActionResult DisplayAllRecord( int page = 1, int limit = 5)
        {
            int skip = (page - 1) * limit;

            var patients = _context.tblPatientRecord
                .OrderByDescending(p => p.LastAccessed) 
                .Skip(skip) // Skip previous pages
                .Take(limit) // Limit results per page
                .ToList();

            return Ok(new { patients, totalRecords = _context.tblPatientRecord.Count() });
        }

    }
}
