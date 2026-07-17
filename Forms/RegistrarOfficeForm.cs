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
    // Registrar Office form
    public partial class RegistrarOfficeForm : Form
    {
        // stores logged-in user info
        private readonly User _currentUser;

        // current active sidebar 
        private string activeSidebar = "student"; // student - course - subject - enrollment

        // holds forms that will open inside the panel
        private Form _activeForm = null;

        // constructor - runs when form is created
        public RegistrarOfficeForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = "Registrar Office";

            handleModule(activeSidebar);

            // auto-load Payment Management when form opens
            OpenChildForm(new StudentManagementForm());
        }

        // opens forms inside panelContent
        private void OpenChildForm(Form childForm)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        // opens Student Management
        private void lblStudents_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StudentManagementForm());
            activeSidebar = "student";
            handleModule(activeSidebar);
        }

        // opens Course Management
        private void lblCourse_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CourseManagementForm());
            activeSidebar = "course";
            handleModule(activeSidebar);
        }

        // opens Subject Management
        private void lblSubjects_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SubjectManagementForm());
            activeSidebar = "subject";
            handleModule(activeSidebar);
        }

        // opens Enrollment Management
        private void lblEnrollments_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EnrollmentManagementForm());
            activeSidebar = "enrollment";
            handleModule(activeSidebar);
        }

        // Handle UI design changes on Sidebar modules
        private void handleModule(string activeModule)
        {
            // reset everything first
            p1.Visible = p2.Visible = p3.Visible = p4.Visible = p5.Visible = p6.Visible = p7.Visible = p8.Visible = false;
            pc1.BackColor = pc2.BackColor = pc3.BackColor = pc4.BackColor = Color.Transparent;

            // set only the ones for the active module
            switch (activeModule)
            {
                case "student":
                    p1.Visible = p2.Visible = true;
                    pc1.BackColor = Color.FromArgb(233, 116, 81);
                    break;
                case "course":
                    p3.Visible = p4.Visible = true;
                    pc2.BackColor = Color.FromArgb(233, 116, 81);
                    break;
                case "subject":
                    p5.Visible = p6.Visible = true;
                    pc3.BackColor = Color.FromArgb(233, 116, 81);
                    break;
                case "enrollment":
                    p7.Visible = p8.Visible = true;
                    pc4.BackColor = Color.FromArgb(233, 116, 81);
                    break;
            }
        }

        // Close current page and return to login page
        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
