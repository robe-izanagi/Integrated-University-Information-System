using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    internal class Fine
    {
        // unique ID for this fine
        public int Id { get; set; }

        // reference to the borrowing record that caused the fine
        public int BorrowingId { get; set; }

        // amount of the fine
        public decimal Amount { get; set; }

        // date the fine was issued
        public DateTime FineDate { get; set; } = DateTime.Now;

        // reason for the fine like "Overdue", "Damaged Book", "Lost Book"
        public string Reason { get; set; } = string.Empty;

        // Pending, Paid, Waived
        public string Status { get; set; } = string.Empty;
    }
}
