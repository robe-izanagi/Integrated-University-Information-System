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
    public class StudentRepository : JsonRepository<Student>
    {
        private static readonly string _filePath = Path.Combine(
            System.Windows.Forms.Application.StartupPath,
            "Data",
            "students.json"
        );
        public StudentRepository() : base(_filePath)
        {
        }
    }
}
