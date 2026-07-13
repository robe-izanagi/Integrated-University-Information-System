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
    internal class ClearanceRepository : JsonRepository<Clearance>
    {
        private static readonly string _filePath = Path.Combine(
            Application.StartupPath,
            "Data",
            "clearances.json"
        );

        public ClearanceRepository() : base(_filePath)
        {
        }
    }
}
