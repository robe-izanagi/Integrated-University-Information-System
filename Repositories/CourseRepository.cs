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
    public class CourseRepository : JsonRepository<Course>
    {
        private static readonly string _filePath = Path.Combine(
            System.Windows.Forms.Application.StartupPath,
            "Data",
            "courses.json"
        );

        public CourseRepository() : base(_filePath)
        {
        }
    }
}
