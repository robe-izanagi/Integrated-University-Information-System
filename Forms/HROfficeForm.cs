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
    public partial class HROfficeForm : Form
    {
        private readonly User _currentUser;
        private Form _activeForm = null;
        public HROfficeForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = "HR Office";
            OpenChildForm(new EmployeeManagementForm());
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

        private void lblEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EmployeeManagementForm());
        }

        private void lblFaculty_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FacultyManagementForm());
        }

        private void lblAttendace_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AttendanceManagementForm());
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
