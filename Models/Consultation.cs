using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    internal class Consultation
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime ConsultationDate { get; set; } = DateTime.Now;
        public string Doctor { get; set; } = string.Empty;
        public string Symptoms { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public string Prescription { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }
}
