using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty; // For security, store hashed password
        public string Role { get; set; } = string.Empty;         // "Admin", "Registrar", "Accounting", "Library", etc.
        public int EmployeeId { get; set; }                     // Reference to Employee.Id - FK
        public bool IsActive { get; set; } = true;
    }
}
