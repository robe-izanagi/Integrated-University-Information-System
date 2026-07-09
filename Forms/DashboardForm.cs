using IntegratedUniversityInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegratedUniversityInformationSystem.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly User _currentUser;
        public DashboardForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = $"IUIS Dashboard - Welcome, {user.Username} ({user.Role})";
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StudentManagementForm());
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CourseManagementForm());
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SubjectManagementForm());
        }

        private void enrollmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EnrollmentManagementForm());
        }

        // Helper Method 
        private void OpenChildForm(Form childForm)
        {
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        // System Menu 
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
