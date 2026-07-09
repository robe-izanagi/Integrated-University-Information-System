using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;   // example - "IT332"
        public string Name { get; set; } = string.Empty;   // example - "Integrative Programming and Technologies"
        public string Description { get; set; } = string.Empty;
        public int Units { get; set; }                    // kung ilang units - 3
        public int CourseId { get; set; }                  // Reference to Course.Id - FK
        public int YearLevel { get; set; }                 // kung anong year ituturo - 3rd year -> 3 
        public string Semester { get; set; } = string.Empty; // kung anong semester ituturo - "1st", "2nd", "Summer class"
        public bool IsActive { get; set; } = true;
    }
}
