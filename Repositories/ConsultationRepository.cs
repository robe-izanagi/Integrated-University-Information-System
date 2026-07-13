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
    internal class ConsultationRepository : JsonRepository<Consultation>
    {
        private static readonly string _filePath = Path.Combine(
            Application.StartupPath,
            "Data",
            "consultations.json"
        );

        public ConsultationRepository() : base(_filePath)
        {
        }
    }
}
