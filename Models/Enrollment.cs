using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }                 // Reference to Student.Id - FK
        public int SubjectId { get; set; }                 // Reference to Subject.Id - FK
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Enrolled";   // "Enrolled", "Dropped", "Completed", "Cancelled"
        public decimal Grade { get; set; }                 // 0.0 to 5.0 (if completed)
        public string Remarks { get; set; } = string.Empty;
    }
}
