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
            switch (activeModule)
            {
                case "employee":
                    p1.Visible = true;
                    p2.Visible = true;
                    p3.Visible = false;
                    p4.Visible = false;
                    p5.Visible = false;
                    p6.Visible = false;
                    pc1.BackColor = Color.Orange;
                    pc2.BackColor = Color.Transparent;
                    pc3.BackColor = Color.Transparent;
                    break;
                case "faculty":
                    p1.Visible = false;
                    p2.Visible = false;
                    p3.Visible = true;
                    p4.Visible = true;
                    p5.Visible = false;
                    p6.Visible = false;
                    pc2.BackColor = Color.Orange;
                    pc1.BackColor = Color.Transparent;
                    pc3.BackColor = Color.Transparent;
                    break;
                case "attendance":
                    p1.Visible = false;
                    p2.Visible = false;
                    p3.Visible = false;
                    p4.Visible = false;
                    p5.Visible = true;
                    p6.Visible = true;
                    pc3.BackColor = Color.Orange;
                    pc1.BackColor = Color.Transparent;
                    pc2.BackColor = Color.Transparent;
                    break;
            }
        }
    }
}
