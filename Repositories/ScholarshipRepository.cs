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
    // repository for handling tuition data (CRUD operations)
    internal class ScholarshipRepository : JsonRepository<Scholarship>
    {
        // path to the tuition JSON file
        private static readonly string _filePath = Path.Combine(
            Application.StartupPath,
            "Data",
            "scholarships.json"
        );

        // constructor - passes file path to the base repository
        public ScholarshipRepository() : base(_filePath)
        {
        }
    }
}
