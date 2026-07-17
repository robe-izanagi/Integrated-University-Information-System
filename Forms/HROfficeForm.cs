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

        // current active sidebar 
        private string activeSidebar = "employee"; // employee - faculty - attendance

        public HROfficeForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = "HR Office";

            handleModule(activeSidebar);
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
            activeSidebar = "employee";
            handleModule(activeSidebar);
        }

        private void lblFaculty_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FacultyManagementForm());
            activeSidebar = "faculty";
            handleModule(activeSidebar);
        }

        private void lblAttendace_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AttendanceManagementForm());
            activeSidebar = "attendance";
            handleModule(activeSidebar);
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void handleModule(string activeModule)
        {
            // reset everything first
            p1.Visible = p2.Visible = p3.Visible = p4.Visible = p5.Visible = p6.Visible = false;
            pc1.BackColor = pc2.BackColor = pc3.BackColor = Color.Transparent;

            // set only the ones for the active module
            switch (activeModule)
            {
                case "employee":
                    p1.Visible = p2.Visible = true;
                    pc1.BackColor = Color.Orange;
                    break;
                case "faculty":
                    p3.Visible = p4.Visible = true;
                    pc2.BackColor = Color.Orange;
                    break;
                case "attendance":
                    p5.Visible = p6.Visible = true;
                    pc3.BackColor = Color.Orange;
                    break;
            }
        }
    }
}
