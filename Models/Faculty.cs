using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    internal class Faculty
    {
        // unique ID for this faculty record
        public int Id { get; set; }

        // reference to the employee ID (from employees.json)
        public int EmployeeId { get; set; }

        // Full Time, Part Time, Guest Lecturer
        public string FacultyType { get; set; } = string.Empty;

        // specialize in like "Web Development", "Networking"
        public string Specialization { get; set; } = string.Empty;

        // subjects they teach - can be comma separated like "IT332, IT331"
        public string SubjectsTaught { get; set; } = string.Empty;

        // years of teaching
        public int YearsTeaching { get; set; }

        // true if still teaching
        public bool IsActive { get; set; } = true;
    }
}
