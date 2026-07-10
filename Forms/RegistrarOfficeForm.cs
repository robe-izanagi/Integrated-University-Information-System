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
    public partial class RegistrarOfficeForm : Form
    {
        private readonly User _currentUser;
        private Form _activeForm = null;
        public RegistrarOfficeForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = "Registrar Office";
            OpenChildForm(new StudentManagementForm());
        }

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

        private void lblStudents_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StudentManagementForm());
        }

        private void lblCourse_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CourseManagementForm());
        }

        private void lblSubjects_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SubjectManagementForm());
        }

        private void lblEnrollments_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EnrollmentManagementForm());
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
