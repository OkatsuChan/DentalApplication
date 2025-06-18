using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DentalApplication.Models
{
    public class PatientRecordModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string TinNumber { get; set; }
        public string Sex { get; set; }
        public string Occupation { get; set; }
        public DateTime? LastAccessed { get; set; }
        public string? ReasonforAccess { get; set; }
        public string? AccessedBy { get; set; }
        public DateOnly DateCreated { get; set; }
    }
}
