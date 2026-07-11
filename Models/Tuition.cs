using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    internal class Tuition
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Semester { get; set; } = string.Empty; // 1st, 2nd, Summer
        public string SchoolYear { get; set; } = string.Empty; // 2025-2026
        public int TotalUnits { get; set; }
        public decimal UnitFee { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Balance { get; set; }
        public string Status { get; set; } = string.Empty; // Pending, Partial, Paid
    }
}
