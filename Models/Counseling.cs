using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    internal class Counseling
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Counselor { get; set; } = string.Empty;
        public DateTime SessionDate { get; set; } = DateTime.Now;
        public string SessionType { get; set; } = string.Empty;
        public string Concern { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string Recommendation { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
