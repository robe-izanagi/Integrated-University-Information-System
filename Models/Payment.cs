using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    internal class Payment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string PaymentMethod { get; set; } = string.Empty; // Cash, Bank Transfer, Credit Card, Check
        public string ReferenceNo { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }
}
