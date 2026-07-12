using IntegratedUniversityInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegratedUniversityInformationSystem.Repositories
{
    internal class EmployeeRepository : JsonRepository<Employee>
    {
        // path to the json file where employees are stored
        private static readonly string _filePath = Path.Combine(
            Application.StartupPath,
            "Data",
            "employees.json"
        );

        // constructor - passes the file path to the base class
        public EmployeeRepository() : base(_filePath)
        {
        }
    }
}
