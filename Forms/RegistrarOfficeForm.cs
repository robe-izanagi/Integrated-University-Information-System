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
            switch (activeModule)
            {
                case "student":
                    p1.Visible = true;
                    p2.Visible = true;
                    p3.Visible = false;
                    p4.Visible = false;
                    p5.Visible = false;
                    p6.Visible = false;
                    p7.Visible = false;
                    p8.Visible = false;
                    pc1.BackColor = Color.FromArgb(233, 116, 81);
                    pc2.BackColor = Color.Transparent;
                    pc3.BackColor = Color.Transparent;
                    pc4.BackColor = Color.Transparent;
                    break;
                case "course":
                    p1.Visible = false;
                    p2.Visible = false;
                    p3.Visible = true;
                    p4.Visible = true;
                    p5.Visible = false;
                    p6.Visible = false;
                    p7.Visible = false;
                    p8.Visible = false;
                    pc2.BackColor = Color.FromArgb(233, 116, 81);
                    pc1.BackColor = Color.Transparent;
                    pc3.BackColor = Color.Transparent;
                    pc4.BackColor = Color.Transparent;
                    break;
                case "subject":
                    p1.Visible = false;
                    p2.Visible = false;
                    p3.Visible = false;
                    p4.Visible = false;
                    p5.Visible = true;
                    p6.Visible = true;
                    p7.Visible = false;
                    p8.Visible = false;
                    pc3.BackColor = Color.FromArgb(233, 116, 81);
                    pc1.BackColor = Color.Transparent;
                    pc2.BackColor = Color.Transparent;
                    pc4.BackColor = Color.Transparent;
                    break;
                case "enrollment":
                    p1.Visible = false;
                    p2.Visible = false;
                    p3.Visible = false;
                    p4.Visible = false;
                    p5.Visible = false;
                    p6.Visible = false;
                    p7.Visible = true;
                    p8.Visible = true;
                    pc4.BackColor = Color.FromArgb(233, 116, 81);
                    pc1.BackColor = Color.Transparent;
                    pc2.BackColor = Color.Transparent;
                    pc3.BackColor = Color.Transparent;
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
