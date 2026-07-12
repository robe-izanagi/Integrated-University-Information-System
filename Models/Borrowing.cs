using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    internal class Borrowing
    {
        // unique ID for this borrowing transaction
        public int Id { get; set; }

        // reference to student who borrowed the book
        public int StudentId { get; set; }

        // reference to the book that was borrowed
        public int BookId { get; set; }

        // date when the book was borrowed
        public DateTime BorrowDate { get; set; } = DateTime.Now;

        // date when the book should be returned
        public DateTime DueDate { get; set; }

        // actual date when the book was returned
        public DateTime? ReturnDate { get; set; }

        // Borrowed, Returned, Overdue, Cancelled
        public string Status { get; set; } = string.Empty;

        // additional notes
        public string Remarks { get; set; } = string.Empty;
    }
}
