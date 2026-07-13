using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    internal class Clearance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime ClearanceDate { get; set; } = DateTime.Now;
        public string Purpose { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public string Restrictions { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }
}
