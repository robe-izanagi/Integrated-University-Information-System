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
    internal class AppointmentRepository : JsonRepository<Appointment>
    {
        private static readonly string _filePath = Path.Combine(
            Application.StartupPath,
            "Data",
            "appointments.json"
        );

        public AppointmentRepository() : base(_filePath)
        {
        }
    }
}
