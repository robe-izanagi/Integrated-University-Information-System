using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    internal class Appointment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime AppointmentDate { get; set; } = DateTime.Now;
        public DateTime AppointmentTime { get; set; } = DateTime.Now;
        public string Purpose { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }
}
