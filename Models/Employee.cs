using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    internal class Employee : Person
    {
        // unique employee number like EMP-001
        public string EmployeeNumber { get; set; } = string.Empty;

        // job position like "IT Manager", "Professor"
        public string Position { get; set; } = string.Empty;

        // department like "IT Department", "HR Department"
        public string Department { get; set; } = string.Empty;

        // when they started working
        public DateTime HireDate { get; set; } = DateTime.Now;

        // Full Time, Part Time, Contractual, Probationary
        public string EmploymentType { get; set; } = string.Empty;

        // for soft delete - true if still working
        public bool IsActive { get; set; } = true;
    }
}
