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
    internal class MedicalRecordRepository : JsonRepository<MedicalRecord>
    {
        private static readonly string _filePath = Path.Combine(
            Application.StartupPath,
            "Data",
            "medical_records.json"
        );

        public MedicalRecordRepository() : base(_filePath)
        {
        }
    }
}
