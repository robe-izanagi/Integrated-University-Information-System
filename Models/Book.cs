using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    internal class Book
    {
        // unique ID for the book
        public int Id { get; set; }

        // International Standard Book Number - unique identifier
        public string ISBN { get; set; } = string.Empty;

        // book title
        public string Title { get; set; } = string.Empty;

        // book author
        public string Author { get; set; } = string.Empty;

        // book publisher
        public string Publisher { get; set; } = string.Empty;

        // year the book was published
        public int YearPublished { get; set; }

        // category like Fiction, Non-Fiction, Science, Technology, etc.
        public string Category { get; set; } = string.Empty;

        // where the book is located in the library like "A-1-3"
        public string Location { get; set; } = string.Empty;

        // total number of copies
        public int Quantity { get; set; }

        // how many copies are available for borrowing
        public int AvailableCopies { get; set; }

        // true if the book is still in the library inventory
        public bool IsActive { get; set; } = true;
    }
}
