using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    public class Student : Person
    {
        public string StudentNumber { get; set; } = string.Empty;
        public int CourseId { get; set; }          // Reference to Course.Id - or FK
        public int YearLevel { get; set; }
        public string Section { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
