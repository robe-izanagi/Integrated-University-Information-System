using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    internal class Scholarship
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string ScholarshipName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // Academic, Athletic, Government, Private
        public decimal Amount { get; set; }
        public DateTime DateAwarded { get; set; } = DateTime.Now;
        public DateTime ExpiryDate { get; set; }
        public string Status { get; set; } = string.Empty; // Active, Expired, Suspended
        public string Remarks { get; set; } = string.Empty;
    }
}
