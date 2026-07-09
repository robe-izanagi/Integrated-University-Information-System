using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;   // example code - "BSIT"
        public string Name { get; set; } = string.Empty;   // example name - "Bachelor of Science in Information Technology"
        public string Description { get; set; } = string.Empty;
        public int DurationYears { get; set; }             // duration, how many yeaars needed to finish the program/course
        public bool IsActive { get; set; } = true;
    }
}
