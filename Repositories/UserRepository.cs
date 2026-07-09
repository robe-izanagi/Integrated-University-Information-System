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
    public class UserRepository : JsonRepository<User>
    {
        private static readonly string _filePath = Path.Combine(
            Application.StartupPath,
            "Data",
            "users.json"
        );

        public UserRepository() : base(_filePath)
        {
        }
    }
}
