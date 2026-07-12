using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    internal class Attendance
    {
        // unique ID for this attendance record
        public int Id { get; set; }

        // reference to employee ID
        public int EmployeeId { get; set; }

        // date of attendance
        public DateTime Date { get; set; } = DateTime.Now;

        // time they clocked in
        public DateTime TimeIn { get; set; }

        // time they clocked out
        public DateTime TimeOut { get; set; }

        // Present, Absent, Late, Half Day, On Leave
        public string Status { get; set; } = string.Empty;

        // any additional notes
        public string Remarks { get; set; } = string.Empty;
    }
}
